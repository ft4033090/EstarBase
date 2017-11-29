using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EstarDXBase.Infrastructure.Tool;
using EstarDXBase.Web.WebUI.Common;
using EstarDXBase.Web.WebUI.Extension.Filters;
using EstarDXBase.Web.Common.Models;

namespace EstarDXBase.Web.WebUI.Areas.SysConfig.Controllers
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
	[AdminPermission(PermissionCustomMode.Ignore)]
	public class AppendixController : AdminController
    {
        //
		// GET: /SysConfig/Config/

		[AdminLayout]
		public ActionResult Icon()
		{
			return View();
		}
	}
}