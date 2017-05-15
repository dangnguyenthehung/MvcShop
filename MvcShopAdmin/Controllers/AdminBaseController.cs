using MvcShopAdmin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcShopAdmin.Controllers
{
    public class AdminBaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (Session[SessionConstant.Admin_Session] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Login",
                    action = "Index"
                    //,Area = "Admin"
                }));
            }
            base.OnActionExecuted(filterContext);
        }
    }
}