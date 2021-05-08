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
    public class MenuController : BaseController
    {
        // GET: Admin/Menu
        public ActionResult Index()
        {
            var dao = new MenuDAO();
            var model = dao.ListAllMenus();
            return View(model);
        }

        public void SetViewBag(int? selectedID = null)
        {
            var dao = new MenuDAO();
            ViewBag.ListTypeMenuID = new SelectList(dao.ListAllMenuType(), "id", "name", selectedID);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        public ActionResult Create(Menu model)
        {
            if (ModelState.IsValid)
            {
                var insert = new MenuDAO().Insert(model);
                if (insert > 0)
                {
                    SetAlert("Tạo menu mới thành công", "success");
                    return RedirectToAction("Index");
                }
                else SetAlert("Tạo menu không thành công", "error");
            }
            SetViewBag(model.typeID);
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var menu = new MenuDAO().GetMenuByID(id);
            SetViewBag(menu.typeID);
            return View(menu);
        }

        [HttpPost]
        public ActionResult Update(Menu model)
        {
            if (ModelState.IsValid)
            {
                var update = new MenuDAO().Update(model);
                if (update)
                {
                    SetAlert("Cập nhật menu thành công", "success");
                    return RedirectToAction("Index");
                }
                else SetAlert("Cập nhật menu không thành công", "error");
            }
            SetViewBag(model.typeID);
            return View();
        }

        public ActionResult Delete(int id)
        {
            var result = new MenuDAO().Delete(id);
            if (result)
                SetAlert("Xóa menu thành công", "success");
            else
                SetAlert("Xóa menu không thành công", "error");
            return RedirectToAction("Index");
        }

    }
}