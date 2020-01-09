namespace website_emp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseversion4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        OptimisticEndTime = c.DateTime(nullable: false),
                        PesimisticEndTime = c.DateTime(nullable: false),
                        CompeletionTime = c.DateTime(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        Department_DepartmentId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.departments", t => t.Department_DepartmentId)
                .ForeignKey("dbo.users", t => t.User_UserId)
                .Index(t => t.Department_DepartmentId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.userGroupTasks",
                c => new
                    {
                        UserGroupTaskId = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        GroupTask_GroupTaskId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.UserGroupTaskId)
                .ForeignKey("dbo.groupTasks", t => t.GroupTask_GroupTaskId)
                .ForeignKey("dbo.users", t => t.User_UserId)
                .Index(t => t.GroupTask_GroupTaskId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.groupTasks",
                c => new
                    {
                        GroupTaskId = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        OptimistictTime = c.DateTime(nullable: false),
                        PesimisicTime = c.DateTime(nullable: false),
                        Task_TaskId = c.Int(),
                    })
                .PrimaryKey(t => t.GroupTaskId)
                .ForeignKey("dbo.tasks", t => t.Task_TaskId)
                .Index(t => t.Task_TaskId);
            
            CreateTable(
                "dbo.tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskDensity = c.String(),
                        Department_DepartmentId = c.Int(),
                        Project_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.departments", t => t.Department_DepartmentId)
                .ForeignKey("dbo.projects", t => t.Project_ProjectId)
                .Index(t => t.Department_DepartmentId)
                .Index(t => t.Project_ProjectId);
            
            CreateTable(
                "dbo.userTasks",
                c => new
                    {
                        UserTaskId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        PesimisticTime = c.DateTime(nullable: false),
                        OptimisticTime = c.DateTime(nullable: false),
                        EndtDate = c.DateTime(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        Task_TaskId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.UserTaskId)
                .ForeignKey("dbo.tasks", t => t.Task_TaskId)
                .ForeignKey("dbo.users", t => t.User_UserId)
                .Index(t => t.Task_TaskId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.userGroupTasks", "User_UserId", "dbo.users");
            DropForeignKey("dbo.userGroupTasks", "GroupTask_GroupTaskId", "dbo.groupTasks");
            DropForeignKey("dbo.userTasks", "User_UserId", "dbo.users");
            DropForeignKey("dbo.userTasks", "Task_TaskId", "dbo.tasks");
            DropForeignKey("dbo.tasks", "Project_ProjectId", "dbo.projects");
            DropForeignKey("dbo.groupTasks", "Task_TaskId", "dbo.tasks");
            DropForeignKey("dbo.tasks", "Department_DepartmentId", "dbo.departments");
            DropForeignKey("dbo.projects", "User_UserId", "dbo.users");
            DropForeignKey("dbo.projects", "Department_DepartmentId", "dbo.departments");
            DropIndex("dbo.userTasks", new[] { "User_UserId" });
            DropIndex("dbo.userTasks", new[] { "Task_TaskId" });
            DropIndex("dbo.tasks", new[] { "Project_ProjectId" });
            DropIndex("dbo.tasks", new[] { "Department_DepartmentId" });
            DropIndex("dbo.groupTasks", new[] { "Task_TaskId" });
            DropIndex("dbo.userGroupTasks", new[] { "User_UserId" });
            DropIndex("dbo.userGroupTasks", new[] { "GroupTask_GroupTaskId" });
            DropIndex("dbo.projects", new[] { "User_UserId" });
            DropIndex("dbo.projects", new[] { "Department_DepartmentId" });
            DropTable("dbo.userTasks");
            DropTable("dbo.tasks");
            DropTable("dbo.groupTasks");
            DropTable("dbo.userGroupTasks");
            DropTable("dbo.projects");
        }
    }
}
