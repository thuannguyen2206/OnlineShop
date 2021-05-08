using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace OnlineShop.Common
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public string roleID { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (UserLogin)HttpContext.Current.Session[CommonConstant.USER_SESSION];
            if (session == null)
                return false;
            List<string> privilegeLevels = GetPermissionByLoggedUser(session.userName);

            if (privilegeLevels.Contains(roleID) || session.groupID == Constans.ADMIN_GROUP)
                return true;
            else
                return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult { ViewName = "~/Areas/Admin/Views/Shared/NoAuthor.cshtml" };
        }

        private List<string> GetPermissionByLoggedUser(string username)
        {
            var permissions = (List<string>)HttpContext.Current.Session[CommonConstant.SESSION_PERMISSION];
            return permissions;
        }

    }
}