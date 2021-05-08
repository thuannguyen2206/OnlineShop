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
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index(string keyword, int pageSize = 1, int page = 1)
        {
            var dao = new CategoryDAO();
            ViewBag.PageSizes = Utilities.GetPageSize(pageSize);
            ViewBag.PageSize = pageSize;
            var model = dao.ListAllPaging(keyword, page, pageSize);
            ViewBag.Search = keyword;
            return View(model);
        }

        public void SetViewBag(int? selectedID = null)
        {
            var dao = new CategoryDAO();
            ViewBag.CategoryID = new SelectList(dao.ListCategory(), "id", "name", selectedID);
        }

        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                var currentCulture = Session[Common.CommonConstant.CurrentCulture];
                var userSession = (UserLogin)Session[Common.CommonConstant.USER_SESSION];
                model.languages = currentCulture.ToString();
                model.createBy=userSession.userName;
                model.createDate = DateTime.Now;
                var id = new CategoryDAO().Insert(model);
                if (id > 0)
                {
                    SetAlert("Tạo danh mục tin tức thành công", "success");
                    return RedirectToAction("Index");
                }else
                {
                    SetAlert("Tạo danh mục tin tức không thành công", "error");
                    //ModelState.AddModelError("", StaticResources.Resource.InsertCategoryFail);
                }
                SetViewBag(model.parentID);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var cate = new CategoryDAO().GetCategoryByID(id);
            SetViewBag(cate.parentID);
            return View(cate);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Update(Category cate)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDAO();
                var userSession = (UserLogin)Session[Common.CommonConstant.USER_SESSION];
                cate.modifyBy = userSession.userName;
                bool id = dao.Update(cate);
                if (id)
                {
                    SetAlert("Cập nhật danh mục tin tức thành công", "success");
                    return RedirectToAction("Index", "Category");
                }
                else
                    SetAlert("Cập nhật danh mục tin tức không thành công", "error");
                //ModelState.AddModelError("", "Chỉnh sửa danh mục tin tức không thành công");
                SetViewBag(cate.parentID);
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            bool del = new CategoryDAO().Delete(id);
            if(del)
                SetAlert("Xóa danh mục tin tức thành công", "success");
            else
                SetAlert("Xóa danh mục tin tức không thành công", "error");
            return RedirectToAction("Index", "Category");
        }

    }
}