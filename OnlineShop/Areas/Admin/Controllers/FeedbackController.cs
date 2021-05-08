using MyDatabase.DAO;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class FeedbackController : BaseController
    {
        // GET: Admin/Feedback
        public ActionResult Index(string searchText, int page = 1, int pageSize = 1)
        {
            var dao = new FeedbackDAO();
            ViewBag.PageSizes = Utilities.GetPageSize(pageSize);
            ViewBag.PageSize = pageSize;
            var model = dao.ListAllPaging(searchText, page, pageSize);
            ViewBag.Search = searchText;//giữ lại chuỗi search trong input
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            bool del = new FeedbackDAO().Delete(id);
            if (del)
                SetAlert("Xóa phản hồi thành công", "success");
            else
                SetAlert("Xóa phản hồi không thành công", "error");
            return RedirectToAction("Index", "Feedback");
        }

    }
}