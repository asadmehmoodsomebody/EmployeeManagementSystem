namespace website_emp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.attendances",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Status = c.String(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("dbo.users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
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
                "dbo.salaryTemplates",
                c => new
                    {
                        SalaryTemplateId = c.Int(nullable: false),
                        Amount = c.Single(nullable: false),
                        AbsentieDeductionPercentage = c.Double(nullable: false),
                        LoanDeductionPercentage = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.SalaryTemplateId)
                .ForeignKey("dbo.departments", t => t.SalaryTemplateId)
                .ForeignKey("dbo.designations", t => t.SalaryTemplateId)
                .Index(t => t.SalaryTemplateId);
            
            CreateTable(
                "dbo.fingerPrints",
                c => new
                    {
                        FingerPrintId = c.Int(nullable: false),
                        FingerPrintPath = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FingerPrintId)
                .ForeignKey("dbo.users", t => t.FingerPrintId)
                .Index(t => t.FingerPrintId);
            
            CreateTable(
                "dbo.leaveRequests",
                c => new
                    {
                        LeaveRequestId = c.Int(nullable: false, identity: true),
                        Reason = c.String(nullable: false, maxLength: 200),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CompletionFlag = c.Boolean(nullable: false),
                        Status_StatusId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.LeaveRequestId)
                .ForeignKey("dbo.status", t => t.Status_StatusId)
                .ForeignKey("dbo.users", t => t.User_UserId)
                .Index(t => t.Status_StatusId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.loanRequests",
                c => new
                    {
                        LoanRequestId = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                        RemainingAmount = c.Double(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.LoanRequestId)
                .ForeignKey("dbo.users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.loanInstallments",
                c => new
                    {
                        LoanInstallmentId = c.Int(nullable: false, identity: true),
                        TotalAmount = c.Double(nullable: false),
                        Paid = c.Double(nullable: false),
                        LoanRequest_LoanRequestId = c.Int(),
                    })
                .PrimaryKey(t => t.LoanInstallmentId)
                .ForeignKey("dbo.loanRequests", t => t.LoanRequest_LoanRequestId)
                .Index(t => t.LoanRequest_LoanRequestId);
            
            CreateTable(
                "dbo.paySlips",
                c => new
                    {
                        PaySlipId = c.Int(nullable: false, identity: true),
                        TotalEarnings = c.Double(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PaySlipId)
                .ForeignKey("dbo.users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.deductions",
                c => new
                    {
                        DeductionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeductionId)
                .ForeignKey("dbo.paySlips", t => t.DeductionId)
                .Index(t => t.DeductionId);
            
            CreateTable(
                "dbo.shifts",
                c => new
                    {
                        ShiftId = c.Int(nullable: false, identity: true),
                        ShiftName = c.String(),
                        StratDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShiftId);
            
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
                "dbo.fines",
                c => new
                    {
                        FineId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Amount = c.Double(nullable: false),
                        Deduction_DeductionId = c.Int(),
                    })
                .PrimaryKey(t => t.FineId)
                .ForeignKey("dbo.deductions", t => t.Deduction_DeductionId)
                .Index(t => t.Deduction_DeductionId);
            
            CreateTable(
                "dbo.holidays",
                c => new
                    {
                        HolidayId = c.Int(nullable: false, identity: true),
                        HolidayDateTime = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HolidayId);
            
            AddColumn("dbo.users", "Shift_ShiftId", c => c.Int());
            CreateIndex("dbo.users", "Shift_ShiftId");
            AddForeignKey("dbo.users", "Shift_ShiftId", "dbo.shifts", "ShiftId");
            DropColumn("dbo.users", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.users", "Role", c => c.String(nullable: false));
            DropForeignKey("dbo.fines", "Deduction_DeductionId", "dbo.deductions");
            DropForeignKey("dbo.userRights", "User_UserId", "dbo.users");
            DropForeignKey("dbo.userRights", "ModuleRight_ModuleRightId", "dbo.moduleRights");
            DropForeignKey("dbo.roleModuleRights", "Role_RoleId", "dbo.roles");
            DropForeignKey("dbo.userRoles", "User_UserId", "dbo.users");
            DropForeignKey("dbo.userRoles", "Role_RoleId", "dbo.roles");
            DropForeignKey("dbo.roleModuleRights", "ModuleRight_ModuleRightId", "dbo.moduleRights");
            DropForeignKey("dbo.moduleRights", "Right_RightId", "dbo.rights");
            DropForeignKey("dbo.moduleRights", "Module_ModuleId", "dbo.modules");
            DropForeignKey("dbo.userGroupTasks", "User_UserId", "dbo.users");
            DropForeignKey("dbo.userGroupTasks", "GroupTask_GroupTaskId", "dbo.groupTasks");
            DropForeignKey("dbo.userTasks", "User_UserId", "dbo.users");
            DropForeignKey("dbo.userTasks", "Task_TaskId", "dbo.tasks");
            DropForeignKey("dbo.tasks", "Project_ProjectId", "dbo.projects");
            DropForeignKey("dbo.groupTasks", "Task_TaskId", "dbo.tasks");
            DropForeignKey("dbo.tasks", "Department_DepartmentId", "dbo.departments");
            DropForeignKey("dbo.users", "Shift_ShiftId", "dbo.shifts");
            DropForeignKey("dbo.paySlips", "User_UserId", "dbo.users");
            DropForeignKey("dbo.deductions", "DeductionId", "dbo.paySlips");
            DropForeignKey("dbo.loanRequests", "User_UserId", "dbo.users");
            DropForeignKey("dbo.loanInstallments", "LoanRequest_LoanRequestId", "dbo.loanRequests");
            DropForeignKey("dbo.leaveRequests", "User_UserId", "dbo.users");
            DropForeignKey("dbo.leaveRequests", "Status_StatusId", "dbo.status");
            DropForeignKey("dbo.fingerPrints", "FingerPrintId", "dbo.users");
            DropForeignKey("dbo.salaryTemplates", "SalaryTemplateId", "dbo.designations");
            DropForeignKey("dbo.salaryTemplates", "SalaryTemplateId", "dbo.departments");
            DropForeignKey("dbo.projects", "User_UserId", "dbo.users");
            DropForeignKey("dbo.projects", "Department_DepartmentId", "dbo.departments");
            DropForeignKey("dbo.attendances", "User_UserId", "dbo.users");
            DropIndex("dbo.fines", new[] { "Deduction_DeductionId" });
            DropIndex("dbo.userRoles", new[] { "User_UserId" });
            DropIndex("dbo.userRoles", new[] { "Role_RoleId" });
            DropIndex("dbo.roleModuleRights", new[] { "Role_RoleId" });
            DropIndex("dbo.roleModuleRights", new[] { "ModuleRight_ModuleRightId" });
            DropIndex("dbo.moduleRights", new[] { "Right_RightId" });
            DropIndex("dbo.moduleRights", new[] { "Module_ModuleId" });
            DropIndex("dbo.userRights", new[] { "User_UserId" });
            DropIndex("dbo.userRights", new[] { "ModuleRight_ModuleRightId" });
            DropIndex("dbo.userTasks", new[] { "User_UserId" });
            DropIndex("dbo.userTasks", new[] { "Task_TaskId" });
            DropIndex("dbo.tasks", new[] { "Project_ProjectId" });
            DropIndex("dbo.tasks", new[] { "Department_DepartmentId" });
            DropIndex("dbo.groupTasks", new[] { "Task_TaskId" });
            DropIndex("dbo.userGroupTasks", new[] { "User_UserId" });
            DropIndex("dbo.userGroupTasks", new[] { "GroupTask_GroupTaskId" });
            DropIndex("dbo.deductions", new[] { "DeductionId" });
            DropIndex("dbo.paySlips", new[] { "User_UserId" });
            DropIndex("dbo.loanInstallments", new[] { "LoanRequest_LoanRequestId" });
            DropIndex("dbo.loanRequests", new[] { "User_UserId" });
            DropIndex("dbo.leaveRequests", new[] { "User_UserId" });
            DropIndex("dbo.leaveRequests", new[] { "Status_StatusId" });
            DropIndex("dbo.fingerPrints", new[] { "FingerPrintId" });
            DropIndex("dbo.salaryTemplates", new[] { "SalaryTemplateId" });
            DropIndex("dbo.projects", new[] { "User_UserId" });
            DropIndex("dbo.projects", new[] { "Department_DepartmentId" });
            DropIndex("dbo.users", new[] { "Shift_ShiftId" });
            DropIndex("dbo.attendances", new[] { "User_UserId" });
            DropColumn("dbo.users", "Shift_ShiftId");
            DropTable("dbo.holidays");
            DropTable("dbo.fines");
            DropTable("dbo.userRoles");
            DropTable("dbo.roles");
            DropTable("dbo.roleModuleRights");
            DropTable("dbo.rights");
            DropTable("dbo.modules");
            DropTable("dbo.moduleRights");
            DropTable("dbo.userRights");
            DropTable("dbo.userTasks");
            DropTable("dbo.tasks");
            DropTable("dbo.groupTasks");
            DropTable("dbo.userGroupTasks");
            DropTable("dbo.shifts");
            DropTable("dbo.deductions");
            DropTable("dbo.paySlips");
            DropTable("dbo.loanInstallments");
            DropTable("dbo.loanRequests");
            DropTable("dbo.leaveRequests");
            DropTable("dbo.fingerPrints");
            DropTable("dbo.salaryTemplates");
            DropTable("dbo.projects");
            DropTable("dbo.attendances");
        }
    }
}
