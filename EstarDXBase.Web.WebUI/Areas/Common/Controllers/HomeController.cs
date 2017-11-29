using EstarDXBase.Web.Common.Models;
using EstarDXBase.Web.WebUI.Common;
using EstarDXBase.Web.WebUI.Extension.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstarDXBase.Web.WebUI.Areas.Common.Controllers
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
	[AdminPermission(PermissionCustomMode.Ignore)]
    public class HomeController : AdminController
    {
        //
        // GET: /Common/Home/

        #region 显示

        [AdminLayout]
        public ActionResult Index()
        {
            return View();
        }

        #endregion

	}
}