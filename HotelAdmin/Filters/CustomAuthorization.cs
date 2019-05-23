using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelAdmin.Filters
{
    public class CustomAuthorization_Admin : AuthorizeAttribute
    {
        public string LoginPage { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (HttpContext.Current.Session["adminId"] == null)
            {
                filterContext.HttpContext.Response.Redirect(LoginPage);
            }

            //if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    filterContext.HttpContext.Response.Redirect(LoginPage);
            //}
            //base.OnAuthorization(filterContext);
        }
    }

    public class CustomAuthorization_Hotel : AuthorizeAttribute
    {
        public string LoginPage { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (HttpContext.Current.Session["HotelId"] == null)
            {
                filterContext.HttpContext.Response.Redirect(LoginPage);
            }

            //if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    filterContext.HttpContext.Response.Redirect(LoginPage);
            //}
            //base.OnAuthorization(filterContext);
        }
    }

    public class CustomAuthorization_User : AuthorizeAttribute
    {
        public string LoginPage { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (HttpContext.Current.Session["UserId"] == null)
            {
                filterContext.HttpContext.Response.Redirect(LoginPage);
            }

            
        }
    }

    }