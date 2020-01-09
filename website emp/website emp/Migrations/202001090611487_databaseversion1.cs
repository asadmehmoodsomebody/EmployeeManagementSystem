namespace website_emp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseversion1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .Index(t => t.DepartmentName, unique: true);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false),
                        Department_DepartmentId = c.Int(),
                        Designation_DesignationId = c.Int(),
                        Status_StatusId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.departments", t => t.Department_DepartmentId)
                .ForeignKey("dbo.designations", t => t.Designation_DesignationId)
                .ForeignKey("dbo.status", t => t.Status_StatusId)
                .Index(t => t.UserName, unique: true)
                .Index(t => t.Email, unique: true)
                .Index(t => t.Department_DepartmentId)
                .Index(t => t.Designation_DesignationId)
                .Index(t => t.Status_StatusId);
            
            CreateTable(
                "dbo.designations",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.DesignationId)
                .Index(t => t.DesignationName, unique: true);
            
            CreateTable(
                "dbo.status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        State = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.StatusId)
                .Index(t => t.State, unique: true);
            
            CreateTable(
                "dbo.userRights",
                c => new
                    {
                        UserRightId = c.Int(nullable: false, identity: true),
                        ModuleRight_ModuleRightId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserRightId)
                .ForeignKey("dbo.moduleRights", t => t.ModuleRight_ModuleRightId, cascadeDelete: true)
                .ForeignKey("dbo.users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.ModuleRight_ModuleRightId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.moduleRights",
                c => new
                    {
                        ModuleRightId = c.Int(nullable: false, identity: true),
                        Module_ModuleId = c.Int(nullable: false),
                        Right_RightId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleRightId)
                .ForeignKey("dbo.modules", t => t.Module_ModuleId, cascadeDelete: true)
                .ForeignKey("dbo.rights", t => t.Right_RightId, cascadeDelete: true)
                .Index(t => t.Module_ModuleId)
                .Index(t => t.Right_RightId);
            
            CreateTable(
                "dbo.modules",
                c => new
                    {
                        ModuleId = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleId);
            
            CreateTable(
                "dbo.rights",
                c => new
                    {
                        RightId = c.Int(nullable: false, identity: true),
                        RightName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RightId);
            
            CreateTable(
                "dbo.roleModuleRights",
                c => new
                    {
                        RoleModuleRightId = c.Int(nullable: false, identity: true),
                        ModuleRight_ModuleRightId = c.Int(nullable: false),
                        Role_RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleModuleRightId)
                .ForeignKey("dbo.moduleRights", t => t.ModuleRight_ModuleRightId, cascadeDelete: true)
                .ForeignKey("dbo.roles", t => t.Role_RoleId, cascadeDelete: true)
                .Index(t => t.ModuleRight_ModuleRightId)
                .Index(t => t.Role_RoleId);
            
            CreateTable(
                "dbo.roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.userRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        Role_RoleId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserRoleId)
                .ForeignKey("dbo.roles", t => t.Role_RoleId, cascadeDelete: true)
                .ForeignKey("dbo.users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Role_RoleId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.SecurityKeys",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.userRights", "User_UserId", "dbo.users");
            DropForeignKey("dbo.userRights", "ModuleRight_ModuleRightId", "dbo.moduleRights");
            DropForeignKey("dbo.roleModuleRights", "Role_RoleId", "dbo.roles");
            DropForeignKey("dbo.userRoles", "User_UserId", "dbo.users");
            DropForeignKey("dbo.userRoles", "Role_RoleId", "dbo.roles");
            DropForeignKey("dbo.roleModuleRights", "ModuleRight_ModuleRightId", "dbo.moduleRights");
            DropForeignKey("dbo.moduleRights", "Right_RightId", "dbo.rights");
            DropForeignKey("dbo.moduleRights", "Module_ModuleId", "dbo.modules");
            DropForeignKey("dbo.users", "Status_StatusId", "dbo.status");
            DropForeignKey("dbo.users", "Designation_DesignationId", "dbo.designations");
            DropForeignKey("dbo.users", "Department_DepartmentId", "dbo.departments");
            DropIndex("dbo.userRoles", new[] { "User_UserId" });
            DropIndex("dbo.userRoles", new[] { "Role_RoleId" });
            DropIndex("dbo.roleModuleRights", new[] { "Role_RoleId" });
            DropIndex("dbo.roleModuleRights", new[] { "ModuleRight_ModuleRightId" });
            DropIndex("dbo.moduleRights", new[] { "Right_RightId" });
            DropIndex("dbo.moduleRights", new[] { "Module_ModuleId" });
            DropIndex("dbo.userRights", new[] { "User_UserId" });
            DropIndex("dbo.userRights", new[] { "ModuleRight_ModuleRightId" });
            DropIndex("dbo.status", new[] { "State" });
            DropIndex("dbo.designations", new[] { "DesignationName" });
            DropIndex("dbo.users", new[] { "Status_StatusId" });
            DropIndex("dbo.users", new[] { "Designation_DesignationId" });
            DropIndex("dbo.users", new[] { "Department_DepartmentId" });
            DropIndex("dbo.users", new[] { "Email" });
            DropIndex("dbo.users", new[] { "UserName" });
            DropIndex("dbo.departments", new[] { "DepartmentName" });
            DropTable("dbo.SecurityKeys");
            DropTable("dbo.userRoles");
            DropTable("dbo.roles");
            DropTable("dbo.roleModuleRights");
            DropTable("dbo.rights");
            DropTable("dbo.modules");
            DropTable("dbo.moduleRights");
            DropTable("dbo.userRights");
            DropTable("dbo.status");
            DropTable("dbo.designations");
            DropTable("dbo.users");
            DropTable("dbo.departments");
        }
    }
}
