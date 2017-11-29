using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EstarDXBase.Infrastructure.Tool;
using EstarDXBase.Core.Service.Authen;
using EstarDXBase.Web.Models.Authen.User;
using EstarDXBase.Infrastructure.Common.SecurityHelper;

namespace EstarDXBase.Web.WebUI.Areas.Common.Controllers
{
	[Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LoginController : Controller
	{
		//
		// GET: /Common/Login/

		#region 属性
		[Import]
        public IUserService UserService { get; set; }
		#endregion

        #region 显示

        public ActionResult Index()
        {
            //TODO:TEST
            var entity = UserService.Users.FirstOrDefault();
            var model = new LoginModel();
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin(LoginModel model)
        {
            OperationResult result = new OperationResult(OperationResultType.Warning, "用户名或密码错误");
            var user = UserService.Users.FirstOrDefault(t => t.LoginName == model.LoginName && t.IsDeleted == false);
            if (user != null)
            {
                if (user.Enabled == false)
                {
                    result = new OperationResult(OperationResultType.Warning, "你的账户已经被禁用");
                }
                else if (DESProvider.DecryptString(user.LoginPwd) == model.LoginPwd)
                {
                    //更新User
                    user.LastLoginTime = DateTime.Now;
                    user.LoginCount += 1;
                    UserService.Update(user);

                    result = new OperationResult(OperationResultType.Success, "登录成功");
                    Session["CurrentUser"] = user;

                    Session.Timeout = 20;
                }
            }
            return Json(result);
        }
        
        #endregion

        #region 注销
        public ActionResult SignOut()
        {
            Session["CurrentUser"] = null;
            return RedirectToAction("Index");
        }
        #endregion

        #region 找回密码
          [HttpPost]
        public ActionResult ForgetPwd()
        {
            return PartialView();
        }
        #endregion
	}
}