﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
//	   如存在本生成代码外的新需求，请在相同命名空间下创建同名分部类进行实现。
// </auto-generated>
//


using System;
using System.ComponentModel.Composition;
using System.Linq;

using EstarDXBase.Infrastructure.Tool;
using EstarDXBase.Domain.Models.Authen;
using EstarDXBase.Core.Repository.Authen;
using EstarDXBase.Web.Models.Authen.Module;


namespace EstarDXBase.Core.Service.Authen.Impl
{
	/// <summary>
    /// 服务层实现 —— ModuleService
    /// </summary>
    [Export(typeof(IModuleService))]
    public class ModuleService : CoreServiceBase, IModuleService
	{
		#region 属性

		[Import]
        public IModuleRepository ModuleRepository { get; set; }

        public IQueryable<Module> Modules
        {
            get { return ModuleRepository.Entities; }
        }

		#endregion

		#region 公共方法

		public OperationResult Insert(ModuleModel model)
        {
            var entity = new Module
            {
                Name = model.Name,
                Code = model.Code,
                ParentId = model.ParentId != 0 ? model.ParentId : null,
                LinkUrl = model.LinkUrl,
                Area = model.Area,
                Controller = model.Controller,
                Action = model.Action,
                OrderSort = model.OrderSort,
                Icon = model.Icon != null ? model.Icon : "",
                Enabled = model.Enabled,
                CreateId = model.CreateId,
				CreateBy = model.CreateBy,
				CreateTime = DateTime.Now,
				ModifyId = model.ModifyId,
				ModifyBy = model.ModifyBy,
                IsMenu = model.IsMenu,
				ModifyTime = DateTime.Now
            };
            ModuleRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "添加成功");
        }

        public OperationResult Update(ModuleModel model)
        {
            var entity = new Module
            {
                Id = model.Id,
                Name = model.Name,
                Code = model.Code,
                ParentId = model.ParentId != 0 ? model.ParentId : null,
                LinkUrl = model.LinkUrl,
                Area = model.Area,
                Controller = model.Controller,
                Action = model.Action,
                OrderSort = model.OrderSort,
				Icon = model.Icon != null ? model.Icon : "",
                Enabled = model.Enabled,
                IsMenu=model.IsMenu,
                CreateId = model.CreateId,
				CreateBy = model.CreateBy,
				CreateTime = DateTime.Now,
				ModifyId = model.ModifyId,
				ModifyBy = model.ModifyBy,
				ModifyTime = DateTime.Now
            };          
            ModuleRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "更新成功");
        }

        public OperationResult Delete(int Id)
        {
			var model = Modules.FirstOrDefault(t => t.Id == Id);
			model.IsDeleted = true;
			ModuleRepository.Update(model);
			return new OperationResult(OperationResultType.Success, "删除成功");
		}

		#endregion
	}
}
