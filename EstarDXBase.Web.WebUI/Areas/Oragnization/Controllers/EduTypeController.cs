using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web.Mvc;
using EstarDXBase.Infrastructure.Tool;
using EstarDXBase.Core.Service.Oragnization;
using EstarDXBase.Web.Common.Models;
using System.Linq.Expressions;
using EstarDXBase.Web.Models.Oragnization.EduType;
using EstarDXBase.Web.WebUI.Common;
using EstarDXBase.Web.WebUI.Extension.Filters;
using EstarDXBase.Domain.Models.Oragnization;


namespace EstarDXBase.Web.WebUI.Areas.Oragnization.Controllers
{ 
	[Export]
	[PartCreationPolicy(CreationPolicy.NonShared)]
    public class EduTypeController : AdminController
    {
        //
        // GET: /Oragnization/EduType/

        #region 属性
        [Import]
        public IEduTypeService EduTypeService { get; set; }

        #endregion

        #region 显示
        [AdminLayout]
        public ActionResult Index()
        {
            var model = new EduTypeModel();
            return View(model);
        }

        [AdminPermission(PermissionCustomMode.Ignore)]
        public ActionResult List(DataTableParameter param)
        {
            int total = EduTypeService.EduTypes.Count(t => t.IsDeleted == false);

            //构建查询表达式
            var expr = BuildSearchCriteria();

            var filterResult = EduTypeService.EduTypes.Where(expr).Select(t => new EduTypeModel
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                OrderSort = t.OrderSort,
                Enabled = t.Enabled
            }).OrderBy(t => t.OrderSort).Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();

            int sortId = param.iDisplayStart + 1;

            var result = from c in filterResult
                         select new[]
                             {
                                 sortId++.ToString(), 
                                 c.Name,
                                 c.Description,
                                 c.OrderSort.ToString(),                                
                                 c.EnabledText,
                                 c.Id.ToString()
                             };

            return Json(new
            {
                sEcho = param.sEcho,
                iDisplayStart = param.iDisplayStart,
                iTotalRecords = total,
                iTotalDisplayRecords = total,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 插入
        public ActionResult Create()
        {
            var model = new EduTypeModel();
            return PartialView(model);
        }

        [HttpPost]
        [AdminOperateLog]
        public ActionResult Create(EduTypeModel model)
        {
            if (ModelState.IsValid)
            {
                this.CreateBaseData<EduTypeModel>(model);
                OperationResult result = EduTypeService.Insert(model);
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
        #endregion

        #region 修改

        public ActionResult Edit(int Id)
        {
            var model = new EduTypeModel();
            var entity = EduTypeService.EduTypes.FirstOrDefault(t => t.Id == Id);
            if (null != entity)
            {
                model = new EduTypeModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    OrderSort = entity.OrderSort,
                    Enabled = entity.Enabled
                };
            }
            return PartialView(model);
        }

        [HttpPost]
        [AdminOperateLog]
        public ActionResult Edit(EduTypeModel model)
        {
            if (ModelState.IsValid)
            {
                this.UpdateBaseData<EduTypeModel>(model);
                OperationResult result = EduTypeService.Update(model);
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
        #endregion

        #region 删除

        [AdminOperateLog]
        public ActionResult Delete(int Id)
        {
            OperationResult result = EduTypeService.Delete(Id);
            return Json(result);
        }

        #endregion

        #region 构建查询表达式
        /// <summary>
        /// 构建查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<EduType, Boolean>> BuildSearchCriteria()
        {
            DynamicLambda<EduType> bulider = new DynamicLambda<EduType>();
            Expression<Func<EduType, Boolean>> expr = null;
            if (!string.IsNullOrEmpty(Request["Name"]))
            {
                var data = Request["Name"].Trim();
                Expression<Func<EduType, Boolean>> tmp = t => t.Name.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (Request["Enabled"] == "0" || Request["Enabled"] == "1")
            {
                var data = Request["Enabled"] == "1" ? true : false;
                Expression<Func<EduType, Boolean>> tmp = t => t.Enabled == data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }

            Expression<Func<EduType, Boolean>> tmpSolid = t => t.IsDeleted == false;
            expr = bulider.BuildQueryAnd(expr, tmpSolid);

            return expr;
        }

        #endregion

	}
}