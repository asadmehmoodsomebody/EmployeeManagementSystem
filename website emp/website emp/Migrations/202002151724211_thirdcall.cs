namespace website_emp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdcall : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendanceId = c.Long(nullable: false),
                        ForDay = c.DateTime(),
                        InTime = c.DateTime(),
                        OutTime = c.DateTime(),
                        Status = c.String(),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        EmployeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("dbo.Employes", t => t.EmployeId, cascadeDelete: true)
                .Index(t => t.EmployeId);
            
            CreateTable(
                "dbo.Employes",
                c => new
                    {
                        EmployeId = c.Long(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 150),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(nullable: false, maxLength: 200),
                        Address = c.String(),
                        Number = c.String(),
                        Education = c.String(),
                        Picture = c.String(),
                        DOB = c.DateTime(),
                        IsMarried = c.Boolean(),
                        Relegion = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        AboutMe = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        IsActive = c.Boolean(),
                        Departmentid = c.Long(nullable: false),
                        DepartmentDesignationId = c.Long(),
                        ShiftId = c.Long(nullable: false),
                        SalaryTemplateId = c.Long(nullable: false),
                        Gender = c.String(),
                        shift_ShiftId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeId)
                .ForeignKey("dbo.Departments", t => t.Departmentid, cascadeDelete: true)
                .ForeignKey("dbo.DepartmentDesignations", t => t.DepartmentDesignationId)
                .ForeignKey("dbo.SalaryTemplates", t => t.SalaryTemplateId, cascadeDelete: true)
                .ForeignKey("dbo.Shifts", t => t.shift_ShiftId)
                .Index(t => t.Departmentid)
                .Index(t => t.DepartmentDesignationId)
                .Index(t => t.SalaryTemplateId)
                .Index(t => t.shift_ShiftId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Long(nullable: false),
                        DepartmentName = c.String(nullable: false, maxLength: 150),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.DepartmentDesignations",
                c => new
                    {
                        DepartmentDesignationId = c.Long(nullable: false),
                        DepartmentId = c.Long(nullable: false),
                        DesignationId = c.Long(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.DepartmentDesignationId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationId = c.Long(nullable: false),
                        DesignationName = c.String(maxLength: 150),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.DesignationId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        ProjectTitle = c.String(maxLength: 150),
                        ProjectDescription = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Createdby = c.Int(nullable: false),
                        Createdon = c.DateTime(nullable: false),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        Deleted = c.Boolean(nullable: false),
                        DepartmentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Long(nullable: false),
                        TaskTitle = c.String(maxLength: 150),
                        TaskDescription = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        OptitimisticTime = c.DateTime(nullable: false),
                        OptimizedTime = c.DateTime(nullable: false),
                        LazyTime = c.DateTime(nullable: false),
                        Points = c.Long(nullable: false),
                        Status = c.String(maxLength: 50),
                        StatusDescription = c.String(),
                        AssignedById = c.Long(nullable: false),
                        AssingedToId = c.Long(nullable: false),
                        Priority = c.String(maxLength: 100),
                        Createdby = c.Int(nullable: false),
                        Createdon = c.DateTime(nullable: false),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        Deleted = c.Boolean(nullable: false),
                        ProjectId = c.Long(nullable: false),
                        Type = c.String(),
                        Module = c.String(),
                        CompletionTime = c.DateTime(),
                        assingedby_EmployeId = c.Long(),
                        assingedto_EmployeId = c.Long(),
                        project_ProjectId = c.Int(),
                        Employe_EmployeId = c.Long(),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Employes", t => t.assingedby_EmployeId)
                .ForeignKey("dbo.Employes", t => t.assingedto_EmployeId)
                .ForeignKey("dbo.Projects", t => t.project_ProjectId)
                .ForeignKey("dbo.Employes", t => t.Employe_EmployeId)
                .Index(t => t.assingedby_EmployeId)
                .Index(t => t.assingedto_EmployeId)
                .Index(t => t.project_ProjectId)
                .Index(t => t.Employe_EmployeId);
            
            CreateTable(
                "dbo.EmployeRoles",
                c => new
                    {
                        EmployeRoleId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                        EmployeId = c.Long(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.EmployeRoleId)
                .ForeignKey("dbo.Employes", t => t.EmployeId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.EmployeId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Long(nullable: false),
                        RoleName = c.String(nullable: false, maxLength: 150),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.RoleModuleRights",
                c => new
                    {
                        RoleModuleRightId = c.Long(nullable: false),
                        ModuleRightId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        employe_EmployeId = c.Long(),
                    })
                .PrimaryKey(t => t.RoleModuleRightId)
                .ForeignKey("dbo.Employes", t => t.employe_EmployeId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.ModuleRights", t => t.ModuleRightId, cascadeDelete: true)
                .Index(t => t.ModuleRightId)
                .Index(t => t.RoleId)
                .Index(t => t.employe_EmployeId);
            
            CreateTable(
                "dbo.FingerPrints",
                c => new
                    {
                        FingerPrintId = c.Long(nullable: false),
                        Fingerprint = c.String(),
                        CreatedOn = c.DateTime(),
                        Modifiedon = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.FingerPrintId)
                .ForeignKey("dbo.Employes", t => t.FingerPrintId)
                .Index(t => t.FingerPrintId);
            
            CreateTable(
                "dbo.Increments",
                c => new
                    {
                        IncreamentId = c.Long(nullable: false),
                        IncrementedOn = c.DateTime(),
                        Amount = c.Long(nullable: false),
                        EmployeId = c.Long(nullable: false),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.IncreamentId)
                .ForeignKey("dbo.Employes", t => t.EmployeId, cascadeDelete: true)
                .Index(t => t.EmployeId);
            
            CreateTable(
                "dbo.Leaves",
                c => new
                    {
                        LeaveId = c.Long(nullable: false),
                        Description = c.String(),
                        startTime = c.DateTime(),
                        endTime = c.DateTime(),
                        IsAccepted = c.Boolean(),
                        TotalDays = c.Int(nullable: false),
                        EmployeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.LeaveId)
                .ForeignKey("dbo.Employes", t => t.EmployeId, cascadeDelete: true)
                .Index(t => t.EmployeId);
            
            CreateTable(
                "dbo.EmployeModuleRights",
                c => new
                    {
                        EmployeModuleRightId = c.Long(nullable: false),
                        ModuleRightId = c.Long(nullable: false),
                        EmployeId = c.Long(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.EmployeModuleRightId)
                .ForeignKey("dbo.Employes", t => t.EmployeId, cascadeDelete: true)
                .ForeignKey("dbo.ModuleRights", t => t.ModuleRightId, cascadeDelete: true)
                .Index(t => t.ModuleRightId)
                .Index(t => t.EmployeId);
            
            CreateTable(
                "dbo.ModuleRights",
                c => new
                    {
                        ModuleRightId = c.Long(nullable: false),
                        ModuleId = c.Long(nullable: false),
                        RightId = c.Long(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.ModuleRightId)
                .ForeignKey("dbo.Modules", t => t.ModuleId, cascadeDelete: true)
                .ForeignKey("dbo.Rights", t => t.RightId, cascadeDelete: true)
                .Index(t => t.ModuleId)
                .Index(t => t.RightId);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ModuleId = c.Long(nullable: false),
                        ModuleName = c.String(nullable: false, maxLength: 150),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.ModuleId);
            
            CreateTable(
                "dbo.Rights",
                c => new
                    {
                        RightId = c.Long(nullable: false),
                        RightName = c.String(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.RightId);
            
            CreateTable(
                "dbo.SalarySlips",
                c => new
                    {
                        SalarySlipId = c.Long(nullable: false),
                        ForMonth = c.DateTime(),
                        EmployeId = c.Long(nullable: false),
                        SalaryTemplateId = c.Long(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        salarytemplate_SalaryTemplateId = c.Long(),
                    })
                .PrimaryKey(t => t.SalarySlipId)
                .ForeignKey("dbo.Employes", t => t.EmployeId, cascadeDelete: true)
                .ForeignKey("dbo.SalaryTemplates", t => t.salarytemplate_SalaryTemplateId)
                .Index(t => t.EmployeId)
                .Index(t => t.salarytemplate_SalaryTemplateId);
            
            CreateTable(
                "dbo.Deductions",
                c => new
                    {
                        DeductionId = c.Long(nullable: false),
                        ComName = c.String(),
                        Amount = c.Long(nullable: false),
                        salaryslipid = c.Long(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.DeductionId)
                .ForeignKey("dbo.SalarySlips", t => t.salaryslipid, cascadeDelete: true)
                .Index(t => t.salaryslipid);
            
            CreateTable(
                "dbo.Earnings",
                c => new
                    {
                        EarningId = c.Long(nullable: false),
                        ComName = c.String(),
                        Amount = c.Double(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        SalarySlipId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.EarningId)
                .ForeignKey("dbo.SalarySlips", t => t.SalarySlipId, cascadeDelete: true)
                .Index(t => t.SalarySlipId);
            
            CreateTable(
                "dbo.SalaryTemplates",
                c => new
                    {
                        SalaryTemplateId = c.Long(nullable: false),
                        TemplateName = c.String(),
                        Payroll = c.Long(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        AbsentiesPercentage = c.Double(nullable: false),
                        IsDeleted = c.Boolean(),
                        salaryslip_SalarySlipId = c.Long(),
                    })
                .PrimaryKey(t => t.SalaryTemplateId)
                .ForeignKey("dbo.SalarySlips", t => t.salaryslip_SalarySlipId)
                .Index(t => t.salaryslip_SalarySlipId);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        ShiftId = c.Int(nullable: false),
                        ShiftStartTime = c.DateTime(),
                        ShiftName = c.String(),
                        ShiftEndTime = c.DateTime(),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.ShiftId);
            
            CreateTable(
                "dbo.MentainanceCounters",
                c => new
                    {
                        MaintainanceCounterId = c.Long(nullable: false),
                        TableName = c.String(nullable: false, maxLength: 150),
                        Count = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.MaintainanceCounterId);
            
            CreateTable(
                "dbo.Holidays",
                c => new
                    {
                        HolidayId = c.Long(nullable: false),
                        HolidayName = c.String(),
                        HolidayDate = c.DateTime(),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.HolidayId);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        LoanId = c.Long(nullable: false),
                        RequestDate = c.DateTime(),
                        DateStartLoan = c.DateTime(),
                        DateEndLoan = c.DateTime(),
                        RequestAmount = c.Double(nullable: false),
                        AllotedAmount = c.Double(nullable: false),
                        ReductionAmount = c.Double(nullable: false),
                        Remaining = c.Double(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedBy = c.Long(),
                        Modifiedon = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        EmployeId = c.Long(nullable: false),
                        IsFinished = c.Boolean(),
                        Accepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LoanId)
                .ForeignKey("dbo.Employes", t => t.EmployeId, cascadeDelete: true)
                .Index(t => t.EmployeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "EmployeId", "dbo.Employes");
            DropForeignKey("dbo.Tasks", "Employe_EmployeId", "dbo.Employes");
            DropForeignKey("dbo.Employes", "shift_ShiftId", "dbo.Shifts");
            DropForeignKey("dbo.SalarySlips", "salarytemplate_SalaryTemplateId", "dbo.SalaryTemplates");
            DropForeignKey("dbo.SalaryTemplates", "salaryslip_SalarySlipId", "dbo.SalarySlips");
            DropForeignKey("dbo.Employes", "SalaryTemplateId", "dbo.SalaryTemplates");
            DropForeignKey("dbo.SalarySlips", "EmployeId", "dbo.Employes");
            DropForeignKey("dbo.Earnings", "SalarySlipId", "dbo.SalarySlips");
            DropForeignKey("dbo.Deductions", "salaryslipid", "dbo.SalarySlips");
            DropForeignKey("dbo.RoleModuleRights", "ModuleRightId", "dbo.ModuleRights");
            DropForeignKey("dbo.ModuleRights", "RightId", "dbo.Rights");
            DropForeignKey("dbo.ModuleRights", "ModuleId", "dbo.Modules");
            DropForeignKey("dbo.EmployeModuleRights", "ModuleRightId", "dbo.ModuleRights");
            DropForeignKey("dbo.EmployeModuleRights", "EmployeId", "dbo.Employes");
            DropForeignKey("dbo.Leaves", "EmployeId", "dbo.Employes");
            DropForeignKey("dbo.Increments", "EmployeId", "dbo.Employes");
            DropForeignKey("dbo.FingerPrints", "FingerPrintId", "dbo.Employes");
            DropForeignKey("dbo.RoleModuleRights", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.RoleModuleRights", "employe_EmployeId", "dbo.Employes");
            DropForeignKey("dbo.EmployeRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.EmployeRoles", "EmployeId", "dbo.Employes");
            DropForeignKey("dbo.Employes", "DepartmentDesignationId", "dbo.DepartmentDesignations");
            DropForeignKey("dbo.Tasks", "project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Tasks", "assingedto_EmployeId", "dbo.Employes");
            DropForeignKey("dbo.Tasks", "assingedby_EmployeId", "dbo.Employes");
            DropForeignKey("dbo.Projects", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Employes", "Departmentid", "dbo.Departments");
            DropForeignKey("dbo.DepartmentDesignations", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.DepartmentDesignations", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Attendances", "EmployeId", "dbo.Employes");
            DropIndex("dbo.Loans", new[] { "EmployeId" });
            DropIndex("dbo.SalaryTemplates", new[] { "salaryslip_SalarySlipId" });
            DropIndex("dbo.Earnings", new[] { "SalarySlipId" });
            DropIndex("dbo.Deductions", new[] { "salaryslipid" });
            DropIndex("dbo.SalarySlips", new[] { "salarytemplate_SalaryTemplateId" });
            DropIndex("dbo.SalarySlips", new[] { "EmployeId" });
            DropIndex("dbo.ModuleRights", new[] { "RightId" });
            DropIndex("dbo.ModuleRights", new[] { "ModuleId" });
            DropIndex("dbo.EmployeModuleRights", new[] { "EmployeId" });
            DropIndex("dbo.EmployeModuleRights", new[] { "ModuleRightId" });
            DropIndex("dbo.Leaves", new[] { "EmployeId" });
            DropIndex("dbo.Increments", new[] { "EmployeId" });
            DropIndex("dbo.FingerPrints", new[] { "FingerPrintId" });
            DropIndex("dbo.RoleModuleRights", new[] { "employe_EmployeId" });
            DropIndex("dbo.RoleModuleRights", new[] { "RoleId" });
            DropIndex("dbo.RoleModuleRights", new[] { "ModuleRightId" });
            DropIndex("dbo.EmployeRoles", new[] { "EmployeId" });
            DropIndex("dbo.EmployeRoles", new[] { "RoleId" });
            DropIndex("dbo.Tasks", new[] { "Employe_EmployeId" });
            DropIndex("dbo.Tasks", new[] { "project_ProjectId" });
            DropIndex("dbo.Tasks", new[] { "assingedto_EmployeId" });
            DropIndex("dbo.Tasks", new[] { "assingedby_EmployeId" });
            DropIndex("dbo.Projects", new[] { "DepartmentId" });
            DropIndex("dbo.DepartmentDesignations", new[] { "DesignationId" });
            DropIndex("dbo.DepartmentDesignations", new[] { "DepartmentId" });
            DropIndex("dbo.Employes", new[] { "shift_ShiftId" });
            DropIndex("dbo.Employes", new[] { "SalaryTemplateId" });
            DropIndex("dbo.Employes", new[] { "DepartmentDesignationId" });
            DropIndex("dbo.Employes", new[] { "Departmentid" });
            DropIndex("dbo.Attendances", new[] { "EmployeId" });
            DropTable("dbo.Loans");
            DropTable("dbo.Holidays");
            DropTable("dbo.MentainanceCounters");
            DropTable("dbo.Shifts");
            DropTable("dbo.SalaryTemplates");
            DropTable("dbo.Earnings");
            DropTable("dbo.Deductions");
            DropTable("dbo.SalarySlips");
            DropTable("dbo.Rights");
            DropTable("dbo.Modules");
            DropTable("dbo.ModuleRights");
            DropTable("dbo.EmployeModuleRights");
            DropTable("dbo.Leaves");
            DropTable("dbo.Increments");
            DropTable("dbo.FingerPrints");
            DropTable("dbo.RoleModuleRights");
            DropTable("dbo.Roles");
            DropTable("dbo.EmployeRoles");
            DropTable("dbo.Tasks");
            DropTable("dbo.Projects");
            DropTable("dbo.Designations");
            DropTable("dbo.DepartmentDesignations");
            DropTable("dbo.Departments");
            DropTable("dbo.Employes");
            DropTable("dbo.Attendances");
        }
    }
}
