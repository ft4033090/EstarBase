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

using EstarDXBase.Domain.Models.Authen;
using EstarDXBase.Core.Repository.Authen;
using EstarDXBase.Web.Models.Authen.Permission;
using EstarDXBase.Infrastructure.Tool;
using System.Collections.Generic;
using EstarDXBase.Web.Common.Models;


namespace EstarDXBase.Core.Service.Authen.Impl
{
	/// <summary>
    /// 服务层实现 —— PermissionService
    /// </summary>
    [Export(typeof(IPermissionService))]
    public class PermissionService : CoreServiceBase, IPermissionService
	{
		#region 属性

		[Import]
        public IPermissionRepository PermissionRepository { get; set; }

        public IQueryable<Permission> Permissions
        {
            get { return PermissionRepository.Entities; }
        }

		#endregion

		#region 公共方法

		/// <summary>
		/// 复选框数据源
		/// </summary>
		/// <returns></returns>
		public List<KeyValueModel> GetKeyValueList()
		{
			var keyValueList = new List<KeyValueModel>();
			var dataList = Permissions.Where(t => t.Enabled == true && t.IsDeleted == false)
								.Select(t=> new PermissionModel
								{
									Id= t.Id,
									Name = t.Name,
									OrderSort = t.OrderSort
								}).OrderBy(t => t.OrderSort).ToList();
			foreach (var data in dataList)
			{
				keyValueList.Add(new KeyValueModel { Text = data.Name, Value = data.Id.ToString() });
			}
			return keyValueList;
		}

        public OperationResult Insert(PermissionModel model)
        {
            var entity = new Permission
            {
                Code = model.Code,
                Icon = model.Icon,
                Name = model.Name,
                Description = model.Description,
                OrderSort = model.OrderSort,
                Enabled = model.Enabled
            };
            PermissionRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "添加成功");
        }

        public OperationResult Update(PermissionModel model)
        {
            var entity = new Permission
            {
                Id = model.Id,
                Code = model.Code,
                Icon = model.Icon,
                Name = model.Name,
                Description = model.Description,
                OrderSort = model.OrderSort,
                Enabled = model.Enabled
            };
            PermissionRepository.Update(entity);
			return new OperationResult(OperationResultType.Success, "更新成功");
        }

        public OperationResult Delete(int Id)
        {
            var model = Permissions.FirstOrDefault(t => t.Id == Id);
            model.IsDeleted = true;

            PermissionRepository.Update(model);
            return new OperationResult(OperationResultType.Success, "删除成功");
		}

		#endregion
	}
}