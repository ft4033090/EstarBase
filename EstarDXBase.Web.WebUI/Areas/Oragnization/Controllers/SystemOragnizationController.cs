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


namespace EstarDXBase.Web.WebUI.Areas.Oragnization.Controllers
{ 
	[Export]
	[PartCreationPolicy(CreationPolicy.NonShared)]
    public class SystemOragnizationController : AdminController
    {
        //
        // GET: /Oragnization/SystemOragnization/

        #region 属性
        [Import]
        public ISystemOragnizationService SystemOragnizationService { get; set; }

        [Import]
        public IEduTypeService EduTypeService { get; set; }
        #endregion

        #region 显示
        [AdminLayout]
        public ActionResult Index()
        {
            var model = new SystemOragnizationModel();

            #region 绑定组织机构和组织机构性质

            model.Search.ParentItems.AddRange(CreateTree());

            var eduTypeData = EduTypeService.EduTypes.Where(t => t.IsDeleted == false && t.Enabled == true && t.Id > 1)
                .Select(t => new EduTypeModel
                {
                    Id = t.Id,
                    Name = t.Name
                });

            foreach (var item in eduTypeData)
            {
                model.Search.EduTypeItems.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });

            }

            #endregion


            return View(model);
        }

        [AdminPermission(PermissionCustomMode.Ignore)]
        public ActionResult List(DataTableParameter param)
        {
            int total = SystemOragnizationService.SystemOragnizations.Count(t => t.IsDeleted == false);

            //构建查询表达式
            var expr = BuildSearchCriteria();

            var filterResult = SystemOragnizationService.SystemOragnizations.Where(expr).Select(t => new SystemOragnizationModel
            {
                Id = t.Id,
                Name = t.Name,
                Phone = t.Phone,
                Email = t.Email,
                Contact = t.Contact,
                IsLocking = t.IsLocking,
                OrderSort = t.OrderSort,
                Enabled = t.Enabled
            }).OrderBy(t => t.OrderSort).Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();

            int sortId = param.iDisplayStart + 1;

            var result = from c in filterResult
                         select new[]
                             {
                                 sortId++.ToString(),
                                 c.Name,
                                 c.Phone,
                                 c.Email,
                                 c.Contact,
                                 c.OrderSort.ToString(), 
                                 c.IsLockingText,
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
            var model = new SystemOragnizationModel();
            InitParentModule(model);
            InitEduTypeModule(model);
            return PartialView(model);
        }

        [HttpPost]
        [AdminOperateLog]
        public ActionResult Create(SystemOragnizationModel model)
        {
            if (ModelState.IsValid)
            {
                this.CreateBaseData<SystemOragnizationModel>(model);
                OperationResult result = SystemOragnizationService.Insert(model);
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
            var model = new SystemOragnizationModel();
            var entity = SystemOragnizationService.SystemOragnizations.FirstOrDefault(t => t.Id == Id);
            if (null != entity)
            {
                model = new SystemOragnizationModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    ParentId = entity.ParentID,
                    EduTypeID = entity.EduTypeID,
                    Phone = entity.Phone,
                    Email = entity.Email,
                    Contact = entity.Contact,
                    ContactPost = entity.ContactPost,
                    IsLocking = entity.IsLocking,
                    OrderSort = entity.OrderSort,
                    Enabled = entity.Enabled,
                    StandardID=entity.StandardID
                };
            }
            InitParentModule(model);
            InitEduTypeModule(model);
            return PartialView(model);
        }

        [HttpPost]
        [AdminOperateLog]
        public ActionResult Edit(SystemOragnizationModel model)
        {
            if (ModelState.IsValid)
            {
                this.UpdateBaseData<SystemOragnizationModel>(model);
                OperationResult result = SystemOragnizationService.Update(model);
                if (result.ResultType == OperationResultType.Success)
                {
                    return Json(result);
                }
                else
                {
                    InitParentModule(model);
                    InitEduTypeModule(model);
                    return PartialView(model);
                }
            }
            else
            {
                InitParentModule(model);
                InitEduTypeModule(model);
                return PartialView(model);
            }
        }
        #endregion

        #region 删除
        [AdminOperateLog]
        public ActionResult Delete(int Id)
        {
            OperationResult result = SystemOragnizationService.Delete(Id);
            return Json(result);
        }
        #endregion

        #region 验证
        /// <summary>
        /// 验证是否存在组织机构名称
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        [AdminPermission(PermissionCustomMode.Ignore)]
        public JsonResult CheckNameExists(string Name)
        {
            bool isExist = false;
            var entity = SystemOragnizationService.SystemOragnizations.FirstOrDefault(t => t.Name == Name);
            if (entity != null)
            {
                isExist = true;
            }
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 验证标准代码是否存在
        /// </summary>
        /// <param name="StandarID"></param>
        /// <returns></returns>
        [AdminPermission(PermissionCustomMode.Ignore)]
        public JsonResult CheckStandardIdExists(string StandardID)
        {

            bool isExist = false;
            var entity = SystemOragnizationService.SystemOragnizations.FirstOrDefault(t => t.StandardID == StandardID);
            if (entity!=null)
            {
                isExist = true;
                
            }
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }
        
        #endregion

        #region 绑定方法
        /// <summary>
        /// 绑定组织机构上级菜单
        /// </summary>
        /// <param name="model"></param>
        private void InitParentModule(SystemOragnizationModel model)
        {

            model.ParentItems.AddRange(CreateTree());
        }

        /// <summary>
        /// 绑定性质菜单
        /// </summary>
        /// <param name="model"></param>
        private void InitEduTypeModule(SystemOragnizationModel model)
        {

            var eduTypeData = EduTypeService.EduTypes.Where(t => t.IsDeleted == false && t.Enabled == true && t.Id > 1)
                   .Select(t => new EduTypeModel
                   {
                       Id = t.Id,
                       Name = t.Name
                   });

            foreach (var item in eduTypeData)
            {
                model.EduTypeItems.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });

            }

        }
        #endregion

        #region 构建查询表达式
        /// <summary>
        /// 构建查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<SystemOragnization, Boolean>> BuildSearchCriteria()
        {
            DynamicLambda<SystemOragnization> bulider = new DynamicLambda<SystemOragnization>();
            Expression<Func<SystemOragnization, Boolean>> expr = null;
            if (!string.IsNullOrEmpty(Request["Name"]))
            {
                var data = Request["Name"].Trim();
                Expression<Func<SystemOragnization, Boolean>> tmp = t => t.Name.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (Request["Enabled"] == "0" || Request["Enabled"] == "1")
            {
                var data = Request["Enabled"] == "1" ? true : false;
                Expression<Func<SystemOragnization, Boolean>> tmp = t => t.Enabled == data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (Request["IsLocking"] == "0" || Request["IsLocking"] == "1")
            {
                var data = Request["IsLocking"] == "1" ? true : false;
                Expression<Func<SystemOragnization, Boolean>> tmp = t => t.IsLocking == data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }

            if (!string.IsNullOrEmpty(Request["ParentId"]) && Request["ParentId"] != "0")
            {
                var data = Convert.ToInt32(Request["ParentId"]);
                Expression<Func<SystemOragnization, Boolean>> tmp = t => (t.ParentID == data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["EduTypeId"]) && Request["EduTypeId"] != "0")
            {
                var data = Convert.ToInt32(Request["EduTypeId"]);
                Expression<Func<SystemOragnization, Boolean>> tmp = t => (t.EduTypeID == data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            Expression<Func<SystemOragnization, Boolean>> tmpSolid = t => t.IsDeleted == false;
            expr = bulider.BuildQueryAnd(expr, tmpSolid);

            return expr;
        }

        #endregion

        #region 创建下拉树列表
        [NonAction]
        private IList<SelectListItem> CreateTree()
        {
            IList<SelectListItem> treeNodes = new List<SelectListItem>();
            IList<SystemOragnization> nodes = SystemOragnizationService.SystemOragnizations.Where(t => t.IsLocking == false && t.Enabled == true && t.IsDeleted == false).ToList();
            addOtherDll("　", 0, nodes, 1, null, ref treeNodes);
            return treeNodes;
        }

        [NonAction]
        protected void addOtherDll(string Pading, int? parentId, IList<SystemOragnization> nodes, int deep, int? showParentId, ref IList<SelectListItem> treeNodes)
        {
            if (deep > 3)
            {
                return;
            }
            SelectListItem item;
            IList<SystemOragnization> tempnodes = nodes.Where(v => v.ParentID == parentId).ToList();
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