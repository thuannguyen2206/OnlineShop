using MyDatabase.DAO;
using MyDatabase.EF;
using OnlineShop.Models;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Common;
using System.Web.Mvc;
using BotDetect.Web.Mvc;
using Facebook;
using System;
using System.Xml.Linq;

namespace OnlineShop.Controllers
{
    public class UserController : Controller
    {
        private Uri RedirectUri
        {
            get {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

        // GET: User
        [HttpGet]
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
                var result = dao.Login(model.userName, Encryptor.MD5Hash(model.password));
                if (result == 1)
                {
                    var user = dao.GetUserByName(model.userName);
                    var userSession = new UserLogin();
                    userSession.userName = user.userName;
                    userSession.userID = user.id;
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return Redirect("/"); 
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản này đã bị khóa");
                }
                else
                {
                    ModelState.AddModelError("", "Thông tin đăng nhập sai");
                }
            }
            else
            {
                ModelState.AddModelError("", "Điền thông tin để đăng nhập");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "registerCaptcha", "Mã xác nhận sai")]
        public ActionResult Register(RegisterModel model)
        {
            ViewBag.Success = false;
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (dao.CheckUserName(model.userName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }else if (dao.CheckEmail(model.email))
                {
                    ModelState.AddModelError("", "Email đã đăng kí cho tài khoản khác");
                }else
                {
                    var user = new User();
                    user.userName = model.userName;
                    user.password = Encryptor.MD5Hash(model.password);
                    user.name = model.name;
                    user.phone = model.phone;
                    user.email = model.email;
                    user.status = true;
                    if (!string.IsNullOrEmpty(model.village))
                        user.address += model.village + ", ";
                    if (!string.IsNullOrEmpty(model.district))
                        user.address += model.district + ", ";
                    if (!string.IsNullOrEmpty(model.province))
                        user.address += model.province;
                    var result = dao.Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = true;
                        model.userName = "";
                        model.name = "";
                        model.phone = "";
                        model.email = "";

                    }else
                    {
                        ModelState.AddModelError("", "Đăng kí không thành công");
                    }
                }
            }
            return View(model);
        }

        public JsonResult LoadProvince()
        {
            var xmlDoc = XDocument.Load(Server.MapPath(@"~/Design/client/data/Provinces_Data.xml"));

            var xElements = xmlDoc.Element("Root").Elements("Item").Where(x => x.Attribute("type").Value == "province");
            var list = new List<ProvinceModel>();
            ProvinceModel province = null;
            foreach (var item in xElements)
            {
                province = new ProvinceModel();
                province.id = int.Parse(item.Attribute("id").Value);
                province.name = item.Attribute("value").Value;
                list.Add(province);
            }
            return Json(new { data=list, status=true});
        }

        public JsonResult LoadDistrict(string province)
        {
            var xmlDoc = XDocument.Load(Server.MapPath(@"~/Design/client/data/Provinces_Data.xml"));

            var xElement = xmlDoc.Element("Root").Elements("Item").Single(x => x.Attribute("type").Value == "province" && x.Attribute("value").Value == province);
            var list = new List<DistrictModel>();
            DistrictModel district = null;
            foreach (var item in xElement.Elements("Item").Where(x=>x.Attribute("type").Value == "district"))
            {
                district = new DistrictModel();
                district.id = int.Parse(item.Attribute("id").Value);
                district.name = item.Attribute("value").Value;
                district.provinceID = int.Parse(xElement.Attribute("id").Value);
                list.Add(district);
            }
            return Json(new { data = list, status = true });
        }

        public JsonResult LoadVillage(string district)
        {
            var xmlDoc = XDocument.Load(Server.MapPath(@"~/Design/client/data/Provinces_Data.xml"));

            var xElement = xmlDoc.Element("Root").Elements("Item").Elements("Item").Single(x => x.Attribute("type").Value == "district" && x.Attribute("value").Value == district);
            var list = new List<VillageModel>();
            VillageModel village = null;
            foreach (var item in xElement.Elements("Item").Where(x => x.Attribute("type").Value == "precinct"))
            {
                village = new VillageModel();
                village.id = int.Parse(item.Attribute("id").Value);
                village.name = item.Attribute("value").Value;
                village.districID = int.Parse(xElement.Attribute("id").Value);
                list.Add(village);
            }
            return Json(new { data = list, status = true });
        }

        public ActionResult Logout()
        {
            Session[Common.CommonConstant.USER_SESSION] = null;
            return Redirect("/");
        }

        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppID"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",
            });
        return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppID"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accesssToken = result.access_token;
            if (!string.IsNullOrEmpty(accesssToken))//đăng nhập thành công
            {
                fb.AccessToken = accesssToken;
                //lấy thông tin tài khoản facebook
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                string firstName = me.first_name;
                string middleName = me.middle_name;
                string lastName = me.last_name;
                string email = me.email;
                string userName = firstName + " " + middleName + " " + lastName;

                var user = new User();
                user.email = email;
                user.userName = userName;
                user.status = true;
                user.name = userName;
                user.createDate = DateTime.Now;

                var resultInsert = new UserDAO().InsertForFacebook(user);
                if (resultInsert > 0)
                {
                    var userSession = new UserLogin();
                    userSession.userName = user.userName;
                    userSession.userID = user.id;
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                }
            }
            return Redirect("/");
        }

    }
}