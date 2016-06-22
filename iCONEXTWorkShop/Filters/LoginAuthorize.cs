using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using iCONEXTWorkShop.Helper;

namespace iCONEXTWorkShop.Filters
{

    public class LoginAuthorize : AuthorizeAttribute
    {
   
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext.Result is HttpUnauthorizedResult)
            {
                var route = new RouteValueDictionary();
                route["controller"] = "Account";
                route["action"] = "Login";
                filterContext.Result= new RedirectToRouteResult(route);
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            try
            {
                int? session = SessionManager.UserData.Id;
                return session != null;
            }
            catch (Exception)
            {

                return false;
            }
            return false;

        }
    }
}