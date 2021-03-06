﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

using EstarDXBase.Infrastructure.EFData;
using EstarDXBase.Domain.Models.Authen;

namespace EstarDXBase.Domain.Data.Mapping.Authen
{
    /// <summary>
    /// 数据表映射 —— PermissionMap
    /// </summary>   
    partial class PermissionMap
    {
        partial void PermissionMapAppend()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Code)
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .HasMaxLength(50);       

            this.Property(t => t.Icon)
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(100);

            // Properties
            this.Property(t => t.CreateBy)
                .HasMaxLength(50);

            this.Property(t => t.ModifyBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Common_Auth_Permission");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);          
            this.Property(t => t.Code).HasColumnName("Code");            
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.OrderSort).HasColumnName("SortOrder");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Icon).HasColumnName("Icon");
            this.Property(t => t.Enabled).HasColumnName("Enabled");

            this.Property(t => t.CreateId).HasColumnName("CreateId");
            this.Property(t => t.CreateBy).HasColumnName("CreateBy");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ModifyId).HasColumnName("ModifyId");
            this.Property(t => t.ModifyBy).HasColumnName("ModifyBy");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
        }
    }
}
