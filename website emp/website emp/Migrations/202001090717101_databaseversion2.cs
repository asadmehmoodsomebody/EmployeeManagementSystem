namespace website_emp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseversion2 : DbMigration
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
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.users", "Shift_ShiftId", "dbo.shifts");
            DropForeignKey("dbo.leaveRequests", "User_UserId", "dbo.users");
            DropForeignKey("dbo.leaveRequests", "Status_StatusId", "dbo.status");
            DropForeignKey("dbo.fingerPrints", "FingerPrintId", "dbo.users");
            DropForeignKey("dbo.attendances", "User_UserId", "dbo.users");
            DropIndex("dbo.leaveRequests", new[] { "User_UserId" });
            DropIndex("dbo.leaveRequests", new[] { "Status_StatusId" });
            DropIndex("dbo.fingerPrints", new[] { "FingerPrintId" });
            DropIndex("dbo.users", new[] { "Shift_ShiftId" });
            DropIndex("dbo.attendances", new[] { "User_UserId" });
            DropColumn("dbo.users", "Shift_ShiftId");
            DropTable("dbo.holidays");
            DropTable("dbo.shifts");
            DropTable("dbo.leaveRequests");
            DropTable("dbo.fingerPrints");
            DropTable("dbo.attendances");
        }
    }
}
