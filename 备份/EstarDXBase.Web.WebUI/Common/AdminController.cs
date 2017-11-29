using EstarDXBase.Infrastructure.Common.ToolsHelper;
using EstarDXBase.Web.Common.Models;
using EstarDXBase.Domain.Models.Authen;
using EstarDXBase.Web.Models.AdminCommon;
using EstarDXBase.Web.Models.Authen.Module;
using EstarDXBase.Web.WebUI.Extension.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EstarDXBase.Web.WebUI.Common
{
	[AdminPermission(PermissionCustomMode.Enforce)]
    public class AdminController : EstarBaseController
    {
       
		public AdminController()
		{
	
		}

        [NonAction]
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            //重定向到错误处理页面
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { area = "Common", controller = "Error", action = "Page500" }));
            Logger.Error("系统出现未处理错误:", filterContext.Exception);
            base.OnException(filterContext);
        }

		protected User GetCurrentUser()
		{
			var user = SessionHelper.GetSession("CurrentUser") as User;
			return user;
		}

		protected void CreateBaseData<T>(T model) where T : EntityCommon
		{
			var user = SessionHelper.GetSession("CurrentUser") as User;
			if (user != null)
			{
				model.CreateId = user.Id;
				model.CreateBy = user.LoginName;
				model.CreateTime = DateTime.Now;
				model.ModifyId = user.Id;
				model.ModifyBy = user.LoginName;
				model.ModifyTime = DateTime.Now;
			}
		}

		protected void UpdateBaseData<T>(T model) where T : EntityCommon
		{
			var user = SessionHelper.GetSession("CurrentUser") as User;
			if (user != null)
			{
				model.ModifyId = user.Id;
				model.ModifyBy = user.LoginName;
				model.ModifyTime = DateTime.Now;
			}
		}
	}
}