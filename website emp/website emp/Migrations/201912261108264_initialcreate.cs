namespace website_emp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
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
                        Role = c.String(nullable: false),
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
            DropForeignKey("dbo.users", "Status_StatusId", "dbo.status");
            DropForeignKey("dbo.users", "Designation_DesignationId", "dbo.designations");
            DropForeignKey("dbo.users", "Department_DepartmentId", "dbo.departments");
            DropIndex("dbo.status", new[] { "State" });
            DropIndex("dbo.designations", new[] { "DesignationName" });
            DropIndex("dbo.users", new[] { "Status_StatusId" });
            DropIndex("dbo.users", new[] { "Designation_DesignationId" });
            DropIndex("dbo.users", new[] { "Department_DepartmentId" });
            DropIndex("dbo.users", new[] { "Email" });
            DropIndex("dbo.users", new[] { "UserName" });
            DropIndex("dbo.departments", new[] { "DepartmentName" });
            DropTable("dbo.SecurityKeys");
            DropTable("dbo.status");
            DropTable("dbo.designations");
            DropTable("dbo.users");
            DropTable("dbo.departments");
        }
    }
}
