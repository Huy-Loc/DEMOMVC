using System.Web.Mvc;

namespace DEMOMVC.Areas.Admins
{
    public class AdminsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admins";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admins_default",
                "Admins/{controller}/{action}/{id}",
                new { areas = "Admins", controller = "HomeAdmin", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}