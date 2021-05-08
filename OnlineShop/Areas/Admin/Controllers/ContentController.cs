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
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index(string searchText, int page = 1, int pageSize = 1)
        {
            var dao = new ContentDAO();
            ViewBag.PageSizes = Utilities.GetPageSize(pageSize);
            ViewBag.PageSize = pageSize;
            var model = dao.ListAllPaging(searchText, page, pageSize);
            ViewBag.Search = searchText;//giữ lại chuỗi search trong input
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Content model)
        {
            if (ModelState.IsValid)
            {
                var session = (UserLogin)Session[CommonConstant.USER_SESSION];
                var culture = Session[CommonConstant.CurrentCulture];
                model.languages = culture.ToString();
                model.createBy = session.userName;
                var insert = new ContentDAO().Create(model);
                if (insert > 0)
                {
                    SetAlert("Tạo tin tức thành công", "success");
                    return RedirectToAction("Index");
                }
                else SetAlert("Tạo tin tức không thành công", "error");
            }
            SetViewBag(model.categoryID);
            return View();
        }

        [HttpGet]
        public ActionResult Update(long id)
        {
            var dao = new ContentDAO();
            var content = dao.GetByID(id);
            SetViewBag(content.categoryID);
            return View(content);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Update(Content model)
        {
            if (ModelState.IsValid)
            {
                var update = new ContentDAO().Update(model);
                if (update > 0)
                {
                    SetAlert("Cập nhật tin tức thành công", "success");
                    return RedirectToAction("Index");
                }
                else SetAlert("Cập nhật tin tức không thành công", "error");
            }
            SetViewBag(model.categoryID);
            return View();
        }

        public void SetViewBag(int? selectedID = null)
        {
            var dao = new CategoryDAO();
            ViewBag.CategoryID = new SelectList(dao.ListCategory(), "id", "name", selectedID);
        }

        public ActionResult Delete(long id)
        {
            var result = new ContentDAO().Delete(id);
            if (result)
                SetAlert("Xóa tin tức thành công", "success");
            else
                SetAlert("Xóa tin tức không thành công", "error");
            return RedirectToAction("Index");
        }

    }
}