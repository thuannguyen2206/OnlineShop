using MyDatabase.DAO;
using OnlineShop.Admin.Models;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.username, Encryptor.MD5Hash(model.password), true);
                if (result == 1)
                {
                    var user = dao.GetUserByName(model.username);
                    var userSession = new UserLogin();
                    userSession.userName = user.userName;
                    userSession.userID = user.id;
                    userSession.groupID = user.groupID;
                    var listPermission = dao.GetListPermission(model.username);
                    Session.Add(CommonConstant.SESSION_PERMISSION, listPermission);
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home"); //Redirect("/Admin/Home/Index");
                }
                else if(result == 0)
                {
                    //ModelState.AddModelError("", "Tài khoản này đã bị khóa");
                    ViewBag.Message = "Tài khoản này đã bị khóa";
                }
                else if (result == -2)
                {
                    //ModelState.AddModelError("", "Tài khoản này không có quyền đăng nhập");
                    ViewBag.Message = "Tài khoản này không có quyền đăng nhập";
                }
                else //result=-1
                {
                    //ModelState.AddModelError("", "Thông tin đăng nhập sai");
                    ViewBag.Message = "Thông tin đăng nhập sai";
                }
            }
            else
            {
                //ModelState.AddModelError("", "Điền thông tin để đăng nhập");
                ViewBag.Message = "Điền thông tin để đăng nhập";
            }
            return View("Login");
        }

        public ActionResult Logout()
        {
            Session[CommonConstant.USER_SESSION] = null;
            return Redirect("Login");
        }

    }
}