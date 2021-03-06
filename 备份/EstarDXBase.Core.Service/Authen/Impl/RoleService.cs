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
using EstarDXBase.Web.Models.Authen.Role;
using System.Collections.Generic;
using EstarDXBase.Web.Common.Models;


namespace EstarDXBase.Core.Service.Authen.Impl
{
	/// <summary>
    /// 服务层实现 —— RoleService
    /// </summary>
    [Export(typeof(IRoleService))]
    public class RoleService : CoreServiceBase, IRoleService
    {
        #region 属性

        [Import]
        public IRoleRepository RoleRepository { get; set; }

        public IQueryable<Role> Roles
        {
            get { return RoleRepository.Entities; }
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
            var dataList = Roles.Where(t => t.Enabled == true && t.IsDeleted == false)
                                .OrderBy(t => t.OrderSort)
								.ToList();
            foreach (var data in dataList)
            {
                keyValueList.Add(new KeyValueModel { Text = data.Name, Value = data.Id.ToString() });
            }
            return keyValueList;
        }

        public OperationResult Insert(RoleModel model)
        {
            var entity = new Role
            {
                Name = model.Name,
                Description = model.Description,
                OrderSort = model.OrderSort,
                Enabled = model.Enabled
            };
            RoleRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "添加成功");
        }

        public OperationResult Update(RoleModel model)
        {
			var entity = Roles.First(t => t.Id == model.Id);
            entity.Name = model.Name;
			entity.Description = model.Description;
			entity.OrderSort = model.OrderSort;
			entity.Enabled = model.Enabled;

            RoleRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "更新成功");
        }

        public OperationResult Delete(int Id)
        {
            var model = Roles.FirstOrDefault(t => t.Id == Id);
            model.IsDeleted = true;

            RoleRepository.Update(model);
            return new OperationResult(OperationResultType.Success, "删除成功");
        }

        #endregion
    }
}
