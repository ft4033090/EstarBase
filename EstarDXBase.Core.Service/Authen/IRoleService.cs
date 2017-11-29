﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
//	   如存在本生成代码外的新需求，请在相同命名空间下创建同名分部类进行实现。
// </auto-generated>
//


using System;
using System.Linq;

using EstarDXBase.Infrastructure.Tool;
using EstarDXBase.Core.Repository.Authen;
using EstarDXBase.Domain.Models.Authen;
using EstarDXBase.Web.Models.Authen.Role;
using System.Collections.Generic;
using EstarDXBase.Web.Common.Models;


namespace EstarDXBase.Core.Service.Authen
{
	/// <summary>
    /// 服务层接口 —— IRoleService
    /// </summary>
    public interface IRoleService
    {
		#region 属性

        IQueryable<Role> Roles { get; }

        #endregion

        #region 公共方法
        /// <summary>
        /// 复选框数据源
        /// </summary>
        /// <returns></returns>
        List<KeyValueModel> GetKeyValueList();

        OperationResult Insert(RoleModel model);

        OperationResult Update(RoleModel model);

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(int Id);

        #endregion
	}
}
