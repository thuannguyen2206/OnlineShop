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
    public class SlideController : BaseController
    {
        // GET: Admin/Slide
        public ActionResult Index()
        {
            var dao = new SlideDAO();
            var model = dao.ListAllSlides();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Slide model)
        {
            if (ModelState.IsValid)
            {
                var session = (UserLogin)Session[CommonConstant.USER_SESSION];
                model.createBy = session.userName;
                model.link = "/";
                model.createDate = DateTime.Now;
                var insert = new SlideDAO().Insert(model);
                if (insert > 0)
                {
                    SetAlert("Tạo slide mới thành công", "success");
                    return RedirectToAction("Index");
                }
                else SetAlert("Tạo slide không thành công", "error");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var slide = new SlideDAO().GetSlideByID(id);
            return View(slide);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Update(Slide model)
        {
            if (ModelState.IsValid)
            {
                var update = new SlideDAO().Update(model);
                if (update)
                {
                    SetAlert("Cập nhật slide thành công", "success");
                    return RedirectToAction("Index");
                }
                else SetAlert("Cập nhật slide không thành công", "error");
            }
            return View();
        }

        public ActionResult Delete(long id)
        {
            var result = new SlideDAO().Delete(id);
            if (result)
                SetAlert("Xóa slide thành công", "success");
            else
                SetAlert("Xóa slide không thành công", "error");
            return RedirectToAction("Index");
        }

    }
}