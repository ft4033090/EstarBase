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
using EstarDXBase.Core.Repository.SysConfig;
using EstarDXBase.Domain.Models.SysConfig;
using EstarDXBase.Web.Common.Models;
using System.Collections.Generic;
using EstarDXBase.Web.Models.SysConfig.OperateLog;


namespace EstarDXBase.Core.Service.SysConfig
{
	/// <summary>
    /// 服务层接口 —— IOperateLogService
    /// </summary>
    public interface IOperateLogService
    {
        #region 属性

        IQueryable<OperateLog> OperateLogs { get; }

        #endregion

        #region 公共方法

        OperationResult Insert(OperateLogModel model);

        OperationResult Delete();

        #endregion
	}
}
