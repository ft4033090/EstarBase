namespace EstarDXBase.Domain.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _default : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Common_Auth_ModulePermission", "ModuleId", "dbo.Common_Auth_Module");
            DropForeignKey("dbo.Common_Auth_RoleModulePermission", "ModuleId", "dbo.Common_Auth_Module");
            DropForeignKey("dbo.Common_Auth_RoleModulePermission", "PermissionId", "dbo.Common_Auth_Permission");
            DropForeignKey("dbo.Common_Edu_SystemOragnization", "EduTypeID", "dbo.Common_Edu_EduType");
            DropForeignKey("dbo.Common_Edu_SystemDepartment", "SystemOragnizationID", "dbo.Common_Edu_SystemOragnization");
            DropForeignKey("dbo.Common_Edu_UserDepartment", "SystemDepartmentID", "dbo.Common_Edu_SystemDepartment");
            DropForeignKey("dbo.SysConfig_OperateLog", "UserId", "dbo.Common_Auth_User");
            DropForeignKey("dbo.Common_Auth_User", "SystemOragnizationID", "dbo.Common_Edu_SystemOragnization");
            DropForeignKey("dbo.Common_Auth_UserRole", "RoleId", "dbo.Common_Auth_Role");
            DropForeignKey("dbo.Common_Auth_UserRole", "UserId", "dbo.Common_Auth_User");
            DropForeignKey("dbo.Common_Edu_UserDepartment", "UserId", "dbo.Common_Auth_User");
            DropForeignKey("dbo.Common_Auth_Role", "SystemOragnizationID", "dbo.Common_Edu_SystemOragnization");
            DropForeignKey("dbo.Common_Auth_RoleModulePermission", "RoleId", "dbo.Common_Auth_Role");
            DropForeignKey("dbo.Common_Auth_ModulePermission", "PermissionId", "dbo.Common_Auth_Permission");
            DropForeignKey("dbo.Common_Auth_Module", "ParentId", "dbo.Common_Auth_Module");
            DropIndex("dbo.Common_Auth_ModulePermission", new[] { "ModuleId" });
            DropIndex("dbo.Common_Auth_RoleModulePermission", new[] { "ModuleId" });
            DropIndex("dbo.Common_Auth_RoleModulePermission", new[] { "PermissionId" });
            DropIndex("dbo.Common_Edu_SystemOragnization", new[] { "EduTypeID" });
            DropIndex("dbo.Common_Edu_SystemDepartment", new[] { "SystemOragnizationID" });
            DropIndex("dbo.Common_Edu_UserDepartment", new[] { "SystemDepartmentID" });
            DropIndex("dbo.SysConfig_OperateLog", new[] { "UserId" });
            DropIndex("dbo.Common_Auth_User", new[] { "SystemOragnizationID" });
            DropIndex("dbo.Common_Auth_UserRole", new[] { "RoleId" });
            DropIndex("dbo.Common_Auth_UserRole", new[] { "UserId" });
            DropIndex("dbo.Common_Edu_UserDepartment", new[] { "UserId" });
            DropIndex("dbo.Common_Auth_Role", new[] { "SystemOragnizationID" });
            DropIndex("dbo.Common_Auth_RoleModulePermission", new[] { "RoleId" });
            DropIndex("dbo.Common_Auth_ModulePermission", new[] { "PermissionId" });
            DropIndex("dbo.Common_Auth_Module", new[] { "ParentId" });
            DropTable("dbo.Common_Auth_Module");
            DropTable("dbo.Common_Auth_ModulePermission");
            DropTable("dbo.Common_Auth_Permission");
            DropTable("dbo.Common_Auth_RoleModulePermission");
            DropTable("dbo.Common_Auth_Role");
            DropTable("dbo.Common_Edu_SystemOragnization");
            DropTable("dbo.Common_Edu_EduType");
            DropTable("dbo.Common_Edu_SystemDepartment");
            DropTable("dbo.Common_Edu_UserDepartment");
            DropTable("dbo.Common_Auth_User");
            DropTable("dbo.SysConfig_OperateLog");
            DropTable("dbo.Common_Auth_UserRole");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Common_Auth_UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CreateId = c.Int(),
                        CreateBy = c.String(maxLength: 50),
                        CreateTime = c.DateTime(),
                        ModifyId = c.Int(),
                        ModifyBy = c.String(maxLength: 50),
                        ModifyTime = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysConfig_OperateLog",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Area = c.String(maxLength: 50),
                        Controller = c.String(maxLength: 50),
                        Action = c.String(maxLength: 50),
                        IPAddress = c.String(maxLength: 50),
                        Description = c.String(maxLength: 50),
                        LogTime = c.DateTime(),
                        LoginName = c.String(maxLength: 50),
                        UserId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Common_Auth_User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginName = c.String(maxLength: 50),
                        LoginPwd = c.String(maxLength: 50),
                        FullName = c.String(),
                        Email = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 20),
                        Enabled = c.Boolean(nullable: false),
                        PwdErrorCount = c.Int(nullable: false),
                        LoginCount = c.Int(nullable: false),
                        RegisterTime = c.DateTime(),
                        LastLoginTime = c.DateTime(),
                        CreateId = c.Int(),
                        CreateBy = c.String(maxLength: 50),
                        CreateTime = c.DateTime(),
                        ModifyId = c.Int(),
                        ModifyBy = c.String(maxLength: 50),
                        ModifyTime = c.DateTime(),
                        SystemOragnizationID = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Common_Edu_UserDepartment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SystemDepartmentID = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Common_Edu_SystemDepartment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        ParentID = c.Int(nullable: false),
                        OrderSort = c.Int(nullable: false),
                        CreateId = c.Int(),
                        CreateBy = c.String(maxLength: 50),
                        CreateTime = c.DateTime(),
                        ModifyId = c.Int(),
                        ModifyBy = c.String(maxLength: 50),
                        ModifyTime = c.DateTime(),
                        Enabled = c.Boolean(nullable: false),
                        SystemOragnizationID = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Common_Edu_EduType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 100),
                        OrderSort = c.Int(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        CreateId = c.Int(),
                        CreateBy = c.String(maxLength: 50),
                        CreateTime = c.DateTime(),
                        ModifyId = c.Int(),
                        ModifyBy = c.String(maxLength: 50),
                        ModifyTime = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Common_Edu_SystemOragnization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        ParentID = c.String(maxLength: 100),
                        LayerFlag = c.String(maxLength: 50),
                        StandarID = c.String(maxLength: 100),
                        Adderss = c.String(maxLength: 100),
                        ZipCode = c.String(maxLength: 10),
                        Phone = c.String(maxLength: 30),
                        Email = c.String(maxLength: 30),
                        Contact = c.String(maxLength: 30),
                        ContactPost = c.String(maxLength: 30),
                        IsLocking = c.Boolean(nullable: false),
                        OrderSort = c.Int(nullable: false),
                        CreateId = c.Int(),
                        CreateBy = c.String(maxLength: 50),
                        CreateTime = c.DateTime(),
                        ModifyId = c.Int(),
                        ModifyBy = c.String(maxLength: 50),
                        ModifyTime = c.DateTime(),
                        Enabled = c.Boolean(nullable: false),
                        EduTypeID = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Common_Auth_Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 100),
                        OrderSort = c.Int(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        CreateId = c.Int(),
                        CreateBy = c.String(maxLength: 50),
                        CreateTime = c.DateTime(),
                        ModifyId = c.Int(),
                        ModifyBy = c.String(maxLength: 50),
                        ModifyTime = c.DateTime(),
                        SystemOragnizationID = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Common_Auth_RoleModulePermission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                        PermissionId = c.Int(),
                        CreateId = c.Int(),
                        CreateBy = c.String(maxLength: 50),
                        CreateTime = c.DateTime(),
                        ModifyId = c.Int(),
                        ModifyBy = c.String(maxLength: 50),
                        ModifyTime = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Common_Auth_Permission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        SortOrder = c.Int(nullable: false),
                        Icon = c.String(maxLength: 100),
                        Description = c.String(maxLength: 100),
                        Enabled = c.Boolean(nullable: false),
                        CreateId = c.Int(),
                        CreateBy = c.String(maxLength: 50),
                        CreateTime = c.DateTime(),
                        ModifyId = c.Int(),
                        ModifyBy = c.String(maxLength: 50),
                        ModifyTime = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Common_Auth_ModulePermission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleId = c.Int(nullable: false),
                        PermissionId = c.Int(nullable: false),
                        CreateId = c.Int(),
                        CreateBy = c.String(maxLength: 50),
                        CreateTime = c.DateTime(),
                        ModifyId = c.Int(),
                        ModifyBy = c.String(maxLength: 50),
                        ModifyTime = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Common_Auth_Module",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        Name = c.String(maxLength: 50),
                        LinkUrl = c.String(maxLength: 100),
                        Area = c.String(),
                        Controller = c.String(),
                        Action = c.String(),
                        Icon = c.String(maxLength: 100),
                        Code = c.String(maxLength: 10),
                        OrderSort = c.Int(nullable: false),
                        Description = c.String(maxLength: 100),
                        IsMenu = c.Boolean(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        CreateId = c.Int(),
                        CreateBy = c.String(maxLength: 50),
                        CreateTime = c.DateTime(),
                        ModifyId = c.Int(),
                        ModifyBy = c.String(maxLength: 50),
                        ModifyTime = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Common_Auth_Module", "ParentId");
            CreateIndex("dbo.Common_Auth_ModulePermission", "PermissionId");
            CreateIndex("dbo.Common_Auth_RoleModulePermission", "RoleId");
            CreateIndex("dbo.Common_Auth_Role", "SystemOragnizationID");
            CreateIndex("dbo.Common_Edu_UserDepartment", "UserId");
            CreateIndex("dbo.Common_Auth_UserRole", "UserId");
            CreateIndex("dbo.Common_Auth_UserRole", "RoleId");
            CreateIndex("dbo.Common_Auth_User", "SystemOragnizationID");
            CreateIndex("dbo.SysConfig_OperateLog", "UserId");
            CreateIndex("dbo.Common_Edu_UserDepartment", "SystemDepartmentID");
            CreateIndex("dbo.Common_Edu_SystemDepartment", "SystemOragnizationID");
            CreateIndex("dbo.Common_Edu_SystemOragnization", "EduTypeID");
            CreateIndex("dbo.Common_Auth_RoleModulePermission", "PermissionId");
            CreateIndex("dbo.Common_Auth_RoleModulePermission", "ModuleId");
            CreateIndex("dbo.Common_Auth_ModulePermission", "ModuleId");
            AddForeignKey("dbo.Common_Auth_Module", "ParentId", "dbo.Common_Auth_Module", "Id");
            AddForeignKey("dbo.Common_Auth_ModulePermission", "PermissionId", "dbo.Common_Auth_Permission", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Common_Auth_RoleModulePermission", "RoleId", "dbo.Common_Auth_Role", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Common_Auth_Role", "SystemOragnizationID", "dbo.Common_Edu_SystemOragnization", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Common_Edu_UserDepartment", "UserId", "dbo.Common_Auth_User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Common_Auth_UserRole", "UserId", "dbo.Common_Auth_User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Common_Auth_UserRole", "RoleId", "dbo.Common_Auth_Role", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Common_Auth_User", "SystemOragnizationID", "dbo.Common_Edu_SystemOragnization", "Id");
            AddForeignKey("dbo.SysConfig_OperateLog", "UserId", "dbo.Common_Auth_User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Common_Edu_UserDepartment", "SystemDepartmentID", "dbo.Common_Edu_SystemDepartment", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Common_Edu_SystemDepartment", "SystemOragnizationID", "dbo.Common_Edu_SystemOragnization", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Common_Edu_SystemOragnization", "EduTypeID", "dbo.Common_Edu_EduType", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Common_Auth_RoleModulePermission", "PermissionId", "dbo.Common_Auth_Permission", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Common_Auth_RoleModulePermission", "ModuleId", "dbo.Common_Auth_Module", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Common_Auth_ModulePermission", "ModuleId", "dbo.Common_Auth_Module", "Id", cascadeDelete: true);
        }
    }
}
