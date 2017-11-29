using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstarDXBase.Web.WebUI.Common
{
    public abstract class EstarBaseController:Controller
    {
        //设置系统日志
        protected readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(EstarBaseController));


        public EstarBaseController() {

            //配置log4net
            log4net.Config.XmlConfigurator.Configure();
        }


        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        { 
        
        
        }
    }
}