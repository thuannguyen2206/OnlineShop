using MyDatabase.DAO;
using MyDatabase.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OnlineShop.Common;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchText, int page = 1, int pageSize = 1)
        {
            var dao = new UserDAO();
            ViewBag.PageSizes = Utilities.GetPageSize(pageSize);
            ViewBag.PageSize = pageSize;
            var model = dao.ListAllPaging(searchText, page, pageSize);
            ViewBag.Search = searchText;//giữ lại chuỗi search trong input
            return View(model);
        }

        public void SetViewBag(string selectedID = null)
        {
            var dao = new UserDAO();
            ViewBag.ListUserGroup = new SelectList(dao.GetListUserGroup(), "id", "name", selectedID);
        }

        [HttpGet]
        [HasPermission(Roles = "ADD_USER")]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        [HasPermission(Roles = "ADD_USER")]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();

                var encryptMD5 = Encryptor.MD5Hash(user.password);
                user.password = encryptMD5;
                user.createDate = DateTime.Now;
                long id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Thêm tài khoản thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    SetAlert("Thêm tài khoản không thành công", "error");
                    //ModelState.AddModelError("", "Thêm tài khoản không thành công");
                }
                SetViewBag(user.groupID);
            }
            return View("Index");
        }

        [HttpGet]
        [HasPermission(Roles = "EDIT_USER")]
        public ActionResult Update(int id)
        {
            var user = new UserDAO().GetUserByID(id);
            SetViewBag(user.groupID);
            return View(user);
        }

        [HttpPost]//lấy thông tin từ web để xử lý
        [HasPermission(Roles = "EDIT_USER")]
        public ActionResult Update(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                bool id = dao.Update(user);
                if (id)
                {
                    SetAlert("Cập nhật tài khoản thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                    SetAlert("Cập nhật tài khoản không thành công", "error");
                //ModelState.AddModelError("", "Chỉnh sửa tài khoản không thành công");
            }
            SetViewBag(user.groupID);
            return View();
        }

        [HasPermission(Roles = "DELETE_USER")]
        public ActionResult Delete(int id)
        {
           var del = new UserDAO().Delete(id);
           if (del)
                SetAlert("Xóa tài khoản thành công", "success"); 
           else
                SetAlert("Cập nhật tài khoản không thành công", "error");
            return RedirectToAction("Index");
        }

        [HttpPost]
        [HasPermission(Roles = "EDIT_USER")]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDAO().ChangeStatus(id);
            return Json(new { status = result });
        }
        
    }
}