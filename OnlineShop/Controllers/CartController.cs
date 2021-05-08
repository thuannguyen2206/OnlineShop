using MyDatabase.DAO;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using MyDatabase.EF;
using System.Configuration;
using Common;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public ActionResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.product.id == item.product.id);
                if (jsonItem != null)
                {
                    item.quantity = jsonItem.quantity;
                }
            }

            Session[CartSession] = sessionCart; 

            return Json(new { status = true});
        }

        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;

            return Json(new { status = true });
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.product.id == id);
            Session[CartSession] = sessionCart;

            return Json(new { status = true });
        }

        public ActionResult AddItem(long productID, int quantity)
        {
            var product = new ProductDAO().ViewDetail(productID);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.product.id == productID))
                {
                    foreach (var item in list)
                    {
                        if (item.product.id == productID)
                        {
                            item.quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tạo đối tượng cart item
                    var item = new CartItem();
                    item.product = product;
                    item.quantity = quantity;
                    list.Add(item);

                    //gán vào session
                    Session[CartSession] = list;
                }

            }
            else
            {
                //tạo đối tượng cart item
                var item = new CartItem();
                item.product = product;
                item.quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(string shipName, string mobile, string email, string address)
        {
            var order = new Order();
            order.shipName = shipName;
            order.shipMobile = mobile;
            order.shipEmail = email;
            order.shipAddress = address;

            try
            {
                var id = new OrderDAO().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailDAO = new OrderDetailDAO();
                double total = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.productID = item.product.id;
                    orderDetail.orderID = id;
                    orderDetail.price = item.product.price;
                    orderDetail.quantity = item.quantity;
                    detailDAO.Insert(orderDetail);

                    total += (item.product.price.GetValueOrDefault(0) * item.quantity);
                }
                //Gửi mail
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Design/client/template/neworder.html"));
                content = content.Replace("{{CustomerName}}", shipName);
                content = content.Replace("{{Phone}}", mobile);
                content = content.Replace("{{Email}}", email);
                content = content.Replace("{{Address}}", address);
                content = content.Replace("{{Total}}", total.ToString("N0"));

                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
                new MailHelper().SendMail(email, "Đơn hàng mới từ OnlineShop", content);
                new MailHelper().SendMail(toEmail, "Đơn hàng mới từ OnlineShop", content);

            }
            catch (Exception)
            {
                return Redirect("/loi-thanh-toan");
            }
            return Redirect("/hoan-thanh");
        }

        public ActionResult Success()
        {
            DeleteAll();
            return View();
        }

        
    }
}