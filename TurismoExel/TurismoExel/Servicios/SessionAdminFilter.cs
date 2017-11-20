using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace TurismoExel.Servicios
{
    public class SessionAdminFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Validar la información que se encuentra en la sesión.
            if (filterContext.HttpContext.Session["SesionAdmin"] == null)
            {
                // Si la información es nula, redireccionar a Login.
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                    { "Controller", "Home" },
                    { "Action", "Login" }
                });
            }

            base.OnActionExecuting(filterContext);
        }
    }
}