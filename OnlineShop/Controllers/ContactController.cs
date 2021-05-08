using MyDatabase.DAO;
using MyDatabase.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var model = new ContactDAO().GetActiveContact();
            return View(model);
        }

        [HttpPost]
        public ActionResult Send(string name, string mobile, string email, string address, string content)
        {
            var feedback = new Feedback();
            feedback.name = name;
            feedback.phone = mobile;
            feedback.email = email;
            feedback.address = address;
            feedback.content = content;
            feedback.createDate = DateTime.Now;
            feedback.status = true;

            var id = new ContactDAO().InsertFeedback(feedback);
            if (id > 0)
            {
                return Json(new { status = true});
            }
            else
            {
                return Json(new { status = false });
            }
        }

    }
}