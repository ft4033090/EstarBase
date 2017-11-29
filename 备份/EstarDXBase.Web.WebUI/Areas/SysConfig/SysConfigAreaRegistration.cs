using System.Web.Mvc;

namespace EstarDXBase.Web.WebUI.Areas.SysConfig
{
	public class SysConfigAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
				return "SysConfig";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
				"SysConfig_default",
				"SysConfig/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
				new string[] { "EstarDXBase.Web.WebUI.Areas.SysConfig.Controllers" }
            );
        }
    }
}