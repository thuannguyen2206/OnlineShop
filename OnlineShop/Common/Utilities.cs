using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Common
{
    public static class Utilities
    {
        public static List<SelectListItem> GetPageSize(int pageSize)
        {
            var pageSizes = new List<SelectListItem>();
            for (int i = 1; i <= 4; i++)
            {
                pageSizes.Add(new SelectListItem() { Value = i.ToString(), Text = i.ToString(), Selected = i == pageSize });
            }

            return pageSizes;
        }
    }
}