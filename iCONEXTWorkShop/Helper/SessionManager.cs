using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iCONEXTWorkShop.ViewModels;

namespace iCONEXTWorkShop.Helper
{
    public static class SessionManager
    {
        public static UserViewModel UserData
        {
            get { return HttpContext.Current.Session["UserData"] as UserViewModel; }
            set { HttpContext.Current.Session["UserData"] = value; }
        }
    }
}