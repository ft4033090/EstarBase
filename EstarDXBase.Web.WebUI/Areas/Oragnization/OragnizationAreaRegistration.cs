using System.Web.Mvc;

namespace EstarDXBase.Web.WebUI.Areas.SysConfig
{
    public class OragnizationRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Oragnization";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Oragnization_default",
                "Oragnization/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "EstarDXBase.Web.WebUI.Areas.Oragnization.Controllers" }
            );
        }
    }
}