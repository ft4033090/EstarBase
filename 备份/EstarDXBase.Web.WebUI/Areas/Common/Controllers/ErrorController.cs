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
    public class ErrorController :Controller
    {
        //
		// GET: /Common/Error/

		public ActionResult Page400()
		{
            return View("Page400");
		}

		public ActionResult Page404()
        {
            return View("Page404");
        }

		public ActionResult Page500()
		{
            return View("Page500");
		}

	}
}