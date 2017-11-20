using System.Web.Mvc;
using TurismoExel.Servicios;

namespace TurismoExel.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new SessionUserFilter());
            filters.Add(new SessionAdminFilter());
        }
    }
}