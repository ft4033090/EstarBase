using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using EstarDXBase.Infrastructure.Tool;
using EstarDXBase.Web.Models.Authen.Role;
using EstarDXBase.Core.Service.Authen;
using EstarDXBase.Core.Service.Oragnization;
using EstarDXBase.Web.Common.Models;
using System.ComponentModel;
using EstarDXBase.Domain.Models.Authen;
using System.Linq.Expressions;
using EstarDXBase.Web.Models.Authen.RoleModulePermission;
using EstarDXBase.Web.Models.Oragnization.EduType;
using EstarDXBase.Web.WebUI.Common;
using EstarDXBase.Web.WebUI.Extension.Filters;
using EstarDXBase.Domain.Models.Oragnization;
using EstarDXBase.Web.Models.Oragnization.SystemOragnization;
using System.Collections;
using System.Text;
using EstarDXBase.Web.Models.Oragnization.SystemDepartments;


namespace EstarDXBase.Web.WebUI.Areas.Oragnization.Controllers
{ 
	[Export]
	[PartCreationPolicy(CreationPolicy.NonShared)]
    public class SystemDepartmentsController : AdminController
    {
        //
        // GET: /Oragnization/SystemDepartments/

        #region 属性
        [Import]
        public ISystemDepartmentService SystemDepartmentService { get; set; }
        #endregion

        #region 显示
        [AdminLayout]
        public ActionResult Index()
        {
            var model = new SystemDepartmentsModel();

            #region 绑定上级部室

            model.Search.ParentItems.AddRange(CreateTree(this.SystemOragnizationID));

            #endregion

            return View(model);
        }

        [AdminPermission(PermissionCustomMode.Ignore)]
        public ActionResult List(DataTableParameter param)
        {
            int total = SystemDepartmentService.SystemDepartments.Count(t => t.IsDeleted == false&&this.SystemOragnizationID==t.SystemOragnizationID);

            //构建查询表达式
            var expr = BuildSearchCriteria();

            var filterResult = SystemDepartmentService.SystemDepartments.Where(expr).Select(t => new SystemDepartmentsModel
            {
                Id = t.Id,
                Name = t.Name,
                OrderSort = t.OrderSort,
                Enabled = t.Enabled
            }).OrderBy(t => t.OrderSort).Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();

            int sortId = param.iDisplayStart + 1;

            var result = from c in filterResult
                         select new[]
                             {
                                 sortId++.ToString(),
                                 c.Name,
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

        #region 增加
        public ActionResult Create()
        {
            var model = new SystemDepartmentsModel();
            InitParentModule(model);
            return PartialView(model);
        }

        [HttpPost]
        [AdminOperateLog]
        public ActionResult Create(SystemDepartmentsModel model)
        {
            if (ModelState.IsValid)
            {
                this.CreateBaseData<SystemDepartmentsModel>(model);
                model.SystemOragnizationID = this.SystemOragnizationID;
                OperationResult result = SystemDepartmentService.Insert(model);
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
            var model = new SystemDepartmentsModel();
            var entity = SystemDepartmentService.SystemDepartments.FirstOrDefault(t => t.Id == Id);
            if (null != entity)
            {
                model = new SystemDepartmentsModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    ParentId = entity.ParentID,
                    OrderSort = entity.OrderSort,
                    Enabled = entity.Enabled,
                    SystemOragnizationID=entity.SystemOragnizationID
                    
                };
            }
            InitParentModule(model);
            return PartialView(model);
        }

        [HttpPost]
        [AdminOperateLog]
        public ActionResult Edit(SystemDepartmentsModel model)
        {
            if (ModelState.IsValid)
            {
                this.UpdateBaseData<SystemDepartmentsModel>(model);
                model.SystemOragnizationID = this.SystemOragnizationID;
                OperationResult result = SystemDepartmentService.Update(model);
                if (result.ResultType == OperationResultType.Success)
                {
                    return Json(result);
                }
                else
                {
                    InitParentModule(model);
                    return PartialView(model);
                }
            }
            else
            {
                InitParentModule(model);
                return PartialView(model);
            }
        }
        #endregion

        #region 删除
        [AdminOperateLog]
        public ActionResult Delete(int Id)
        {
            OperationResult result = SystemDepartmentService.Delete(Id);
            return Json(result);
        }
        #endregion

        #region 绑定方法
        /// <summary>
        /// 绑定组织机构上级菜单
        /// </summary>
        /// <param name="model"></param>
        private void InitParentModule(SystemDepartmentsModel model)
        {

            model.ParentItems.AddRange(CreateTree(this.SystemOragnizationID));
        }
        #endregion

        #region 构建查询表达式
        /// <summary>
        /// 构建查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<SystemDepartment, Boolean>> BuildSearchCriteria()
        {
            DynamicLambda<SystemDepartment> bulider = new DynamicLambda<SystemDepartment>();
            Expression<Func<SystemDepartment, Boolean>> expr = null;
            if (!string.IsNullOrEmpty(Request["Name"]))
            {
                var data = Request["Name"].Trim();
                Expression<Func<SystemDepartment, Boolean>> tmp = t => t.Name.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (Request["Enabled"] == "0" || Request["Enabled"] == "1")
            {
                var data = Request["Enabled"] == "1" ? true : false;
                Expression<Func<SystemDepartment, Boolean>> tmp = t => t.Enabled == data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["ParentId"]) && Request["ParentId"] != "0")
            {
                var data = Convert.ToInt32(Request["ParentId"]);
                Expression<Func<SystemDepartment, Boolean>> tmp = t => (t.ParentID == data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            Expression<Func<SystemDepartment, Boolean>> tmpSolid = t => t.IsDeleted == false;
            expr = bulider.BuildQueryAnd(expr, tmpSolid);

            return expr;
        }

        #endregion

        #region 创建下拉树列表
        [NonAction]
        private IList<SelectListItem> CreateTree(int currentUserSystemOragnizationID)
        {
            IList<SelectListItem> treeNodes = new List<SelectListItem>();
            IList<SystemDepartment> nodes = SystemDepartmentService.SystemDepartments.Where(t => t.Enabled == true && t.IsDeleted == false && currentUserSystemOragnizationID==t.SystemOragnizationID).ToList();
            addOtherDll("　", 0, nodes, 1, null, ref treeNodes);
            return treeNodes;
        }

        [NonAction]
        protected void addOtherDll(string Pading, int? parentId, IList<SystemDepartment> nodes, int deep, int? showParentId, ref IList<SelectListItem> treeNodes)
        {
            if (deep > 3)
            {
                return;
            }
            SelectListItem item;
            IList<SystemDepartment> tempnodes = nodes.Where(v => v.ParentID == parentId).ToList();
            foreach (var node in tempnodes)
            {
                item = new SelectListItem();
                StringBuilder strPading = new StringBuilder();
                for (int j = 0; j < deep - 1; j++)
                {
                    //用全角的空格  
                    strPading.Append(Pading);
                }
                //添加节点  
                if (parentId.HasValue)
                {
                    item.Text = strPading + "|--" + node.Name;
                }
                else
                    item.Text = " + " + node.Name;
                item.Value = node.Id.ToString();
                item.Selected = node.Id == showParentId;
                treeNodes.Add(item);
                //递归调用addOtherDll函数，在函数中把deep加1  
                addOtherDll(Pading, node.Id, nodes, deep + 1, showParentId, ref treeNodes);
            }
        }

        #endregion
	}
}