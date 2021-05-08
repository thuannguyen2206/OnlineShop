using MyDatabase.DAO;
using MyDatabase.EF;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string searchText, int cateID = 1, int page = 1, int pageSize = 5)
        {
            var dao = new ProductDAO();
            ViewBag.PageSizes = Utilities.GetPageSize(pageSize);
            ViewBag.PageSize = pageSize;
            SetViewBag(cateID);
            ViewBag.Search = searchText;
            var result = dao.ListAllPaging(searchText, cateID, page, pageSize);
            return View(result);
        }
            
        public void SetViewBag(int? selectedID = null)
        {
            var dao = new ProductDAO();
            ViewBag.ListCategory = new SelectList(dao.GetListProductCategory(), "id", "name", selectedID);
            ViewBag.CateID = selectedID;
        }

        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                var userSession = (UserLogin)Session[CommonConstant.USER_SESSION];
                model.createBy = userSession.userName;
                model.createDate = DateTime.Now;
                model.viewCount = 0;
                model.includeVAT = 0;
                model.quantity = 0;
                var id = new ProductDAO().Insert(model);
                if (id > 0)
                {
                    SetAlert("Tạo mới sản phẩm thành công", "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("Tạo mới sản phẩm không thành công", "error");
                    //ModelState.AddModelError("", StaticResources.Resource.InsertCategoryFail);
                }
            }
            SetViewBag(model.categoryID);
            return View();
        }

        [HttpGet]
        public ActionResult Update(long id)
        {
            var product = new ProductDAO().GetProductByID(id);
            SetViewBag(product.categoryID);
            return View(product);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();
                var userSession = (UserLogin)Session[CommonConstant.USER_SESSION];
                product.modifyBy = userSession.userName;
                bool id = dao.Update(product);
                if (id)
                {
                    SetAlert("Cập nhật thông tin sản phẩm thành công", "success");
                    return RedirectToAction("Index");
                }
                else
                    SetAlert("Cập nhật thông tin sản phẩm không thành công", "error");
            }
            SetViewBag(product.categoryID);
            return View();
        }

        public ActionResult Delete(long id)
        {
            var result = new ProductDAO().Delete(id);
            if (result)
                SetAlert("Xóa sản phẩm thành công", "success");
            else
                SetAlert("Xóa sản phẩm không thành công", "error");
            return RedirectToAction("Index");
        }

        public JsonResult ChangeStatus(long id)
        {
            var result = new ProductDAO().ChangeStatus(id);
            return Json(new { status = result });
        }

    }
}