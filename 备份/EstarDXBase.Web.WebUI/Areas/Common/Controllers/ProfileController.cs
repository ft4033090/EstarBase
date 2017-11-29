using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EstarDXBase.Infrastructure.Tool;
using EstarDXBase.Web.WebUI.Extension.Filters;
using EstarDXBase.Web.Common.Models;
using EstarDXBase.Web.WebUI.Common;
using EstarDXBase.Web.Models.AdminCommon;
using EstarDXBase.Web.Models.Authen.User;
using EstarDXBase.Infrastructure.Common.ToolsHelper;
using EstarDXBase.Domain.Models.Authen;
using EstarDXBase.Infrastructure.Common.SecurityHelper;
using EstarDXBase.Core.Service.Authen;

namespace EstarDXBase.Web.WebUI.Areas.Common.Controllers
{	
	[Export]
	[PartCreationPolicy(CreationPolicy.NonShared)]
    [AdminPermission(PermissionCustomMode.Ignore)]
	public class ProfileController : AdminController
    {
        //
        // GET: /Common/Profile/
        #region 属性
        [Import]
		public IUserService UserService { get; set; }
        #endregion

        [AdminLayout]
        public ActionResult Index()
        {
			var entity = this.GetCurrentUser();
			var model = new ProfileModel { 
				Id = entity.Id,
				LoginName = entity.LoginName,
				Email = entity.Email,
				FullName = entity.FullName,
				Phone = entity.Phone,
				LoginCount = entity.LoginCount,
				LastLoginTime = entity.LastLoginTime,
				RegisterTime = entity.RegisterTime
			};
			return View(model);
        }

		[AdminLayout]
		public ActionResult ChangePwd()
		{
			var entity = this.GetCurrentUser();
			var model = new ChangePwdModel { 
				Id = entity.Id,
				LoginName = entity.LoginName,
				Email = entity.Email
			};
			return View(model);
		}

		[HttpPost]
		public ActionResult ChangePwd(ChangePwdModel model)
		{
			if (ModelState.IsValid)
			{
				OperationResult result = UserService.Update(model);
				if (result.ResultType == OperationResultType.Success)
				{
					return Json(result);
				}
				else
				{
					return PartialView(model);
				}
			}
			else
			{
				return PartialView(model);
			}
		}

		public ActionResult CheckPwd(string oldLoginPwd)
		{
			bool result = true;
			var user = SessionHelper.GetSession("CurrentUser") as User;
			if (DESProvider.DecryptString(user.LoginPwd) != oldLoginPwd)
			{
				result = false;
			}
			return Json(result, JsonRequestBehavior.AllowGet);
		}
	}
}