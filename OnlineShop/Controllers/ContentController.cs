using MyDatabase.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace OnlineShop.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var model = new ContentDAO().ListAllPagingForClient(page, pageSize);
            return View(model);
        }

        public ActionResult Detail(long id)
        {
            var model = new ContentDAO().GetByID(id);
            ViewBag.Tags = new ContentDAO().ListTags(id);
            return View(model);
        }

        public ActionResult Tags(string tagID, int page = 1, int pageSize = 1)
        {
            var model = new ContentDAO().ListAllContentByTag(tagID, page, pageSize);
            ViewBag.Tag = new ContentDAO().GetTag(tagID);
            return View(model);
        }

    }
}