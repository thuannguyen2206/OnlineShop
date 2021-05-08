using MyDatabase.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int page=1, int pageSize=12)
        {
            var model = new ProductDAO().ListProduct(page, pageSize);
            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDAO().ListAllProductCategory();
            return PartialView(model);
        }

        public ActionResult Category(int id, int page = 1, int pageSize = 2 )
        {
            var category = new CategoryDAO().ViewDetail(id);
            ViewBag.Category = category;
            var model = new ProductDAO().ListProductByCategoryID(id, page, pageSize);
            return View(model);
        }

        [OutputCache(Duration = int.MaxValue, VaryByParam = "id", Location =System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Detail(long id)
        {
            var product = new ProductDAO().ViewDetail(id);
            ViewBag.Category = new ProductCategoryDAO().ViewDetail(product.categoryID);
            ViewBag.Related = new ProductDAO().ListRelatedProduct(id);
            return View(product);
        }

        public JsonResult ListName(string q)
        {
            var data = new ProductDAO().ListName(q);
            return Json(new { data = data, status = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(string keyword, int page = 1, int pageSize = 2)
        {
            ViewBag.Keyword = keyword;
            var model = new ProductDAO().Search(keyword, page, pageSize);
            return View(model);
        }

    }
}