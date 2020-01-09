namespace website_emp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseversion3 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.paySlips", "User_UserId", "dbo.users");
            DropForeignKey("dbo.deductions", "DeductionId", "dbo.paySlips");
            DropForeignKey("dbo.loanRequests", "User_UserId", "dbo.users");
            DropForeignKey("dbo.loanInstallments", "LoanRequest_LoanRequestId", "dbo.loanRequests");
            DropForeignKey("dbo.salaryTemplates", "SalaryTemplateId", "dbo.designations");
            DropForeignKey("dbo.salaryTemplates", "SalaryTemplateId", "dbo.departments");
            DropIndex("dbo.deductions", new[] { "DeductionId" });
            DropIndex("dbo.paySlips", new[] { "User_UserId" });
            DropIndex("dbo.loanInstallments", new[] { "LoanRequest_LoanRequestId" });
            DropIndex("dbo.loanRequests", new[] { "User_UserId" });
            DropIndex("dbo.salaryTemplates", new[] { "SalaryTemplateId" });
            DropTable("dbo.deductions");
            DropTable("dbo.paySlips");
            DropTable("dbo.loanInstallments");
            DropTable("dbo.loanRequests");
            DropTable("dbo.salaryTemplates");
        }
    }
}
