using MyDatabase.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Common;
using OnlineShop.Models;
using System.Configuration;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Slides = new SlideDAO().ListAllSlides();
            var productDAO = new ProductDAO();
            ViewBag.NewProducts = productDAO.ListNewProduct(12);
            ViewBag.FeatureProducts = productDAO.ListFeatureProduct(12);
            //SEO cho website
            ViewBag.Title = ConfigurationManager.AppSettings["HomeTitle"];
            ViewBag.Keywords = ConfigurationManager.AppSettings["HomeKeyword"];
            ViewBag.Descriptions = ConfigurationManager.AppSettings["HomeDescription"];

            return View();
        }

        [ChildActionOnly]
        [OutputCache( Duration = 3600 * 24)]
        public ActionResult MainMenu()
        {
            var model = new MenuDAO().ListMenuByTypeID(1);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var model = new MenuDAO().ListMenuByTypeID(2);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult HeaderCart()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }

    }
}