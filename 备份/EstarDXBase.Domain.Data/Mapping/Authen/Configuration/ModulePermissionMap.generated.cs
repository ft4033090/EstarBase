﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

using EstarDXBase.Infrastructure.EFData;
using EstarDXBase.Domain.Models.Authen;


namespace EstarDXBase.Domain.Data.Mapping.Authen
{
    /// <summary>
    /// 数据表映射 —— ModulePermission
    /// </summary>    
	internal partial class ModulePermissionMap : EntityTypeConfiguration<ModulePermission>, IEntityMapper
    {
        /// <summary>
        /// ModulePermission-数据表映射构造函数
        /// </summary>
        public ModulePermissionMap()
        {
			ModulePermissionMapAppend();
        }

		/// <summary>
        /// 额外的数据映射
        /// </summary>
        partial void ModulePermissionMapAppend();
		
        /// <summary>
        /// 将当前实体映射对象注册到当前数据访问上下文实体映射配置注册器中
        /// </summary>
        /// <param name="configurations">实体映射配置注册器</param>
        public void RegistTo(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}
