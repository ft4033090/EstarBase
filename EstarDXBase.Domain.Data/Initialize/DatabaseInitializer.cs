using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

using EstarDXBase.Infrastructure.EFData;
using EstarDXBase.Domain.Data.Migrations;

namespace EstarDXBase.Domain.Data.Initialize
{
    /// <summary>
    /// 数据库初始化操作类
    /// </summary>
    public static class DatabaseInitializer
    {
        /// <summary>
        /// 数据库初始化
        /// </summary>
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFDbContext, Configuration>());
		
		}
    }
}
