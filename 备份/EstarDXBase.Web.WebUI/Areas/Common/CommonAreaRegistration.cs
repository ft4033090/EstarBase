using System.Web.Mvc;

namespace EstarDXBase.Web.WebUI.Areas.Common
{
    public class CommonAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Common";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Common_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "EstarDXBase.Web.WebUI.Areas.Common.Controllers" }
            );
        }
    }
}