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
    public class ProductCategoryController : BaseController
    {
        // GET: Admin/ProductCategory
        public ActionResult Index(string searchText, int page = 1, int pageSize = 5)
        {
            var dao = new ProductCategoryDAO();
            ViewBag.PageSizes = Utilities.GetPageSize(pageSize);
            ViewBag.PageSize = pageSize;
            var model = dao.ListAllPaging(searchText, page, pageSize);
            ViewBag.Search = searchText;//giữ lại chuỗi search trong input
            return View(model);
        }

        public void SetViewBag(int? selectedID = null)
        {
            var dao = new ProductCategoryDAO();
            ViewBag.ListCategory = new SelectList(dao.GetListProductCategory(), "id", "name", selectedID);
        }

        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(ProductsCategory model)
        {
            if (ModelState.IsValid)
            {
                var userSession = (UserLogin)Session[CommonConstant.USER_SESSION];
                model.createBy = userSession.userName;
                model.createDate = DateTime.Now;
                var id = new ProductCategoryDAO().Insert(model);
                if (id > 0)
                {
                    SetAlert("Thêm danh mục sản phẩm thành công", "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("Thêm danh mục sản phẩm không thành công", "error");
                    //ModelState.AddModelError("", StaticResources.Resource.InsertCategoryFail);
                }
            }
            SetViewBag(model.parentID);
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var catepro = new ProductCategoryDAO().GetProductCategoryByID(id);
            SetViewBag(catepro.parentID);
            return View(catepro);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Update(ProductsCategory procate)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDAO();
                var userSession = (UserLogin)Session[Common.CommonConstant.USER_SESSION];
                procate.modifyBy = userSession.userName;
                bool id = dao.Update(procate);
                if (id)
                {
                    SetAlert("Cập nhật danh mục sản phẩm thành công", "success");
                    return RedirectToAction("Index");
                }
                else
                    SetAlert("Cập nhật danh mục không thành công", "error");
                    //ModelState.AddModelError("", "Chỉnh sửa danh mục sản phẩm không thành công");
            }
            SetViewBag(procate.parentID);
            return View();
        }

        public ActionResult Delete(int id)
        {
            var del = new ProductCategoryDAO().Delete(id);
            if (del)
                SetAlert("Xóa danh mục sản phẩm thành công", "success");
            else
                SetAlert("Xóa danh mục sản phẩm không thành công", "error");
            return RedirectToAction("Index");
        }

    }
}