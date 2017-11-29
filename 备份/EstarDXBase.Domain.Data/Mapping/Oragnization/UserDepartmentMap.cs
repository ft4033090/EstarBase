﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations.Schema;

using EstarDXBase.Infrastructure.EFData;
using EstarDXBase.Domain.Models.Oragnization;


namespace EstarDXBase.Domain.Data.Mapping.Oragnization
{
    /// <summary>
    /// 数据表映射 —— UserDepartment
    /// </summary>    
	partial class UserDepartmentMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void UserDepartmentMapAppend()
        {
			// Primary Key
            this.HasKey(t => t.Id);

            // Properties
            
            // Table & Column Mappings
            this.ToTable("Common_Edu_UserDepartment");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.SystemDepartmentID).HasColumnName("SystemDepartmentID");
            
            // Relation
            this.HasRequired(t => t.SystemDepartment).WithMany(d =>d.UserDepartment).HasForeignKey(f => f.SystemDepartmentID).WillCascadeOnDelete(true);
            this.HasRequired(t => t.User).WithMany(d => d.UserDepartment).HasForeignKey(f => f.UserId).WillCascadeOnDelete(true);

        }

		
    }
}
