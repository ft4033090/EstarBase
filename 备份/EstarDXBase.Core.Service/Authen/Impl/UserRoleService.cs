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
using EstarDXBase.Infrastructure.Tool;


namespace EstarDXBase.Core.Service.Authen.Impl
{
	/// <summary>
    /// 服务层实现 —— UserRoleService
    /// </summary>
    [Export(typeof(IUserRoleService))]
    public class UserRoleService : IUserRoleService
	{
		#region 属性

		[Import]
        public IUserRoleRepository UserRoleRepository { get; set; }

        public IQueryable<UserRole> UserRoles
        {
            get { return UserRoleRepository.Entities; }
		}

		#endregion
	}
}
