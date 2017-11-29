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
using System.Web.Http;
using System.Web.Mvc;

namespace EstarDXBase.Web.WebUI.Common
{
	[AdminPermission(PermissionCustomMode.Enforce)]
    public class AdminController : Controller
    {
        public int SystemOragnizationID { get; set; }
        public int EduTypeID { get; set; }
        public List<int> SystemDepartmentIDs { get; set; }
		public AdminController()
		{
            SystemOragnizationID = GetCurrentUser().SystemOragnizationID;
            EduTypeID = GetCurrentUser().SystemOragnization.EduTypeID;
            var UserDepartment= GetCurrentUser().UserDepartment.ToList();
            foreach (var item in UserDepartment)
            {
                SystemDepartmentIDs.Add(item.SystemDepartmentID);
      
            }

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