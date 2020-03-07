namespace website_emp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<website_emp.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        //public void myseed(website_emp.Models.Context context)
        //{
        //    Seed(context);
        //}
        protected override void Seed(website_emp.Models.Context context)
        {
            try {
                DateTime tempdate = DateTime.Now;
                context.counter.AddOrUpdate(
               new Models.MentainanceCounter() { MaintainanceCounterId = 1, Count = 4, TableName = "Attendance" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 2, Count = 1, TableName = "Deduction" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 3, Count = 2, TableName = "Department" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 4, Count = 2, TableName = "Designation" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 5, Count = 4, TableName = "DepartmentDesignation" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 6, Count = 1, TableName = "Earning" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 7, Count = 3, TableName = "Employe" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 8, Count = 0, TableName = "EmployeModuleRight" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 9, Count = 3, TableName = "EmployeRole" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 10, Count = 0, TableName = "FingerPrint" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 11, Count = 1, TableName = "Holiday" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 12, Count = 0, TableName = "Increment" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 13, Count = 2, TableName = "Leave" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 14, Count = 1, TableName = "Loan" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 15, Count = 0, TableName = "Module" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 16, Count = 0, TableName = "ModuleRight" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 17, Count = 2, TableName = "Project" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 18, Count = 0, TableName = "Right" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 19, Count = 2, TableName = "Role" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 20, Count = 0, TableName = "RoleModuleRight" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 21, Count = 4, TableName = "Invoice" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 22, Count = 1, TableName = "SalaryTemplate" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 23, Count = 2, TableName = "Shift" },
               new Models.MentainanceCounter() { MaintainanceCounterId = 24, Count = 13, TableName = "Task" },
               new Models.MentainanceCounter() { MaintainanceCounterId=25,Count=0,TableName="LoanInstallment"}
              );
                context.SaveChanges();
                context.department.AddOrUpdate(
                       new Models.Department
                       {
                           CreatedBy = 1,
                           DepartmentId = 1,
                           IsDeleted = false,
                           DepartmentName = "IT",
                           CreatedOn = DateTime.Now
                       }, new Models.Department
                       {
                           CreatedBy = 1,
                           DepartmentId = 2,
                           IsDeleted = false,
                           DepartmentName = "Management",
                           CreatedOn = DateTime.Now
                       }
                       );
                context.SaveChanges();
                context.designation.AddOrUpdate(
                       new Models.Designation
                       {
                           CreatedBy = 1,
                           CreatedOn = DateTime.Now,
                           IsDeleted = false,
                           DesignationName = "Manager",
                           DesignationId = 1,
                       },
                       new Models.Designation
                       {
                           CreatedBy = 1,
                           CreatedOn = DateTime.Now,
                           IsDeleted = false,
                           DesignationName = "HR",
                           DesignationId = 2,
                       }
                       );
                context.SaveChanges();
                context.shift.AddOrUpdate(
                    new Models.Shift { CreatedBy = 1, ShiftName = "Morning", CreatedOn = DateTime.Now, IsDeleted = false, ShiftId = 1, ShiftStartTime = DateTime.Parse("2/12/2020 08:00 AM"), ShiftEndTime = DateTime.Parse("2/12/2020 05:00 PM") },
                    new Models.Shift { CreatedBy = 1, ShiftName = "Evening", CreatedOn = DateTime.Now, IsDeleted = false, ShiftId = 2, ShiftStartTime = DateTime.Parse("2/12/2020 06:00 PM"), ShiftEndTime = DateTime.Parse("3/12/2020 03:00 AM") }
                    );
                context.SaveChanges();
                context.role.AddOrUpdate(
                       new Models.Role { RoleId = 1, RoleName = "Admin", CreatedBy = 1, CreatedOn = DateTime.Now, IsDeleted = false },
                       new Models.Role { RoleId = 2, RoleName = "User", CreatedBy = 1, CreatedOn = DateTime.Now, IsDeleted = false }
                       );
                context.SaveChanges();

                context.employe.AddOrUpdate(
                    new Models.Employe
                    {
                        EmployeId = 1,
                        IsDeleted = false,
                        CreatedBy = 1,
                        CreatedOn = DateTime.Now,
                        Address = "Sultan Garhi Risalpur cantt",
                        Departmentid = 1,
                        DOB = DateTime.Now,
                        Email = "Asad7121209@hotmail.com",
                        IsMarried = false,
                        FirstName = "Asad",
                        LastName = "Mehmood",
                        IsActive = true,
                        Password = "hunter001",
                        UserName = "Asad_hunter",
                        ShiftId = 1,
                        Gender = "Male",
                        Relegion = "Islam",
                        Picture = "dummy",
                        Education = "MCS",
                        City = "Nowshera",
                        Country = "Pakistan",
                        AboutMe = "I am software engineer",
                        shift = context.shift.Find(1),
                        department = context.department.Find(1),
                        Designationid = 1,
                        designation = context.designation.Find(1),
                        Salary=50000,
                        EmployeType = "Permanent"
                        
                    }, new Models.Employe
                    {
                        EmployeId = 2,
                        IsDeleted = false,
                        CreatedBy = 1,
                        CreatedOn = DateTime.Now,
                        Address = "Pabbi",
                        Departmentid = 1,
                        DOB = DateTime.Now,
                        Gender = "Male",
                        Email = "Asad7121208@hotmail.com",
                        IsMarried = false,
                        FirstName = "Muhammad",
                        LastName = "Ismail",
                        IsActive = true,
                        Password = "users",
                        UserName = "ismail_user",
                        ShiftId = 1,
                        Relegion = "Islam",
                        Picture = "dummy1",
                        Education = "MCS",
                        City = "Pabbi",
                        Country = "Pakistan",
                        AboutMe = "I am Design Engineer",
                        shift = context.shift.Find(1),
                        Designationid =1,
                        designation = context.designation.Find(1),
                        department = context.department.Find(1),
                        Salary= 20000,
                        EmployeType = "Permanent"
                    }
                       );
                context.SaveChanges();

                context.employerole.AddOrUpdate(
                       new Models.EmployeRole
                       {
                           CreatedOn = DateTime.Now,
                           CreatedBy = 1,
                           EmployeId = 1,
                           EmployeRoleId = 1,
                           employe = context.employe.Find(1),
                           role = context.role.Find(1),
                           RoleId = 1,
                           IsDeleted = false
                       },
                       new Models.EmployeRole
                       {
                           CreatedOn = DateTime.Now,
                           CreatedBy = 1,
                           EmployeId = 1,
                           EmployeRoleId = 2,
                           RoleId = 2,
                           employe = context.employe.Find(1),
                           role = context.role.Find(2),
                           IsDeleted = false
                       },
                       new Models.EmployeRole
                       {
                           CreatedOn = DateTime.Now,
                           CreatedBy = 1,
                           EmployeId = 2,
                           EmployeRoleId = 3,
                           RoleId = 2,
                           employe = context.employe.Find(2),
                           role = context.role.Find(2),
                           IsDeleted = false
                       }
                       );
                context.SaveChanges();

                context.project.AddOrUpdate(
                    new Models.Project
                    {
                        Createdby = 1,
                        Createdon = DateTime.Now,
                        Deleted = false,
                        department = context.department.Find(1)
                    ,
                        DepartmentId = 1,
                        EndDate = null,
                        StartDate = DateTime.Now,
                        ProjectDescription = "Project for Pakistan",
                        ProjectId = 1,
                        ProjectTitle = "EMR",
                        task = new List<Models.Task>()
                    },
                    new Models.Project
                    {
                        Createdby = 1,
                        Createdon = DateTime.Now,
                        Deleted = false,
                        department = context.department.Find(1)
                    ,
                        DepartmentId = 1,
                        EndDate = null,
                        StartDate = DateTime.Now,
                        ProjectDescription = "Project for Pakistan",
                        ProjectId = 2,
                        ProjectTitle = "EMS",
                        task = new List<Models.Task>()
                    }
                    );
                context.task.AddOrUpdate(
                    new Models.Task
                    {
                        TaskId = 1,
                        TaskTitle = "Dummy Task",
                        TaskDescription = "Dummy task has no descriptions",
                        Createdon = DateTime.Now,
                        Createdby = 1,
                        AssignedById = 1,
                        AssingedToId = 1,
                        assingedby = context.employe.Find(1),
                        assingedto = context.employe.Find(1),
                        Type = "Bug",
                        Status = "Ongoing",
                        StatusDescription = "Ongoing",
                        ProjectId = 1,
                        project = context.project.Find(1),
                        Priority = "High",
                        StartDate = DateTime.Now,
                        Deleted = false,
                        LazyTime = DateTime.Now,
                        OptimizedTime = DateTime.Now,
                        OptitimisticTime = DateTime.Now,
                        Module = "Management",
                        Points = 8,
                        CompletionTime = null
                    },
                     new Models.Task
                     {
                         TaskId = 2,
                         TaskTitle = "Dummy Task",
                         TaskDescription = "Dummy task has no descriptions",
                         Createdon = DateTime.Now,
                         Createdby = 1,
                         AssignedById = 1,
                         AssingedToId = 2,
                         assingedby = context.employe.Find(1),
                         assingedto = context.employe.Find(2),
                         Type = "Bug",
                         Status = "Ongoing",
                         StatusDescription = "Ongoing",
                         ProjectId = 1,
                         project = context.project.Find(1),
                         Priority = "High",
                         StartDate = DateTime.Now,
                         Deleted = false,
                         LazyTime = DateTime.Now,
                         OptimizedTime = DateTime.Now,
                         OptitimisticTime = DateTime.Now,
                         Module = "Management",
                         Points = 8,
                         CompletionTime = null
                     },
                      new Models.Task
                      {
                          TaskId = 3,
                          TaskTitle = "Dummy Task",
                          TaskDescription = "Dummy task has no descriptions",
                          Createdon = DateTime.Now,
                          Createdby = 1,
                          AssignedById = 1,
                          AssingedToId = 2,
                          assingedby = context.employe.Find(1),
                          assingedto = context.employe.Find(2),
                          Type = "Bug",
                          Status = "Ongoing",
                          StatusDescription = "Ongoing",
                          ProjectId = 2,
                          project = context.project.Find(2),
                          Priority = "High",
                          StartDate = DateTime.Now,
                          Deleted = false,
                          LazyTime = DateTime.Now,
                          OptimizedTime = DateTime.Now,
                          OptitimisticTime = DateTime.Now,
                          Module = "Management",
                          Points = 8,
                          CompletionTime = null
                      },
                       new Models.Task
                       {
                           TaskId = 4,
                           TaskTitle = "Dummy Task",
                           TaskDescription = "Dummy task has no descriptions",
                           Createdon = DateTime.Now,
                           Createdby = 1,
                           AssignedById = 1,
                           AssingedToId = 2,
                           assingedby = context.employe.Find(1),
                           assingedto = context.employe.Find(2),
                           Type = "Bug",
                           Status = "Ongoing",
                           StatusDescription = "Ongoing",
                           ProjectId = 2,
                           project = context.project.Find(2),
                           Priority = "High",
                           StartDate = DateTime.Now,
                           Deleted = false,
                           LazyTime = DateTime.Now,
                           OptimizedTime = DateTime.Now,
                           OptitimisticTime = DateTime.Now,
                           Module = "Management",
                           Points = 8,
                           CompletionTime = null
                       },
                        new Models.Task
                        {
                            TaskId = 7,
                            TaskTitle = "Dummy Task",
                            TaskDescription = "Dummy task has no descriptions",
                            Createdon = DateTime.Now,
                            Createdby = 1,
                            AssignedById = 1,
                            AssingedToId = 2,
                            assingedby = context.employe.Find(1),
                            assingedto = context.employe.Find(2),
                            Type = "Bug",
                            Status = "Ongoing",
                            StatusDescription = "Ongoing",
                            ProjectId = 2,
                            project = context.project.Find(2),
                            Priority = "High",
                            StartDate = DateTime.Now,
                            Deleted = false,
                            LazyTime = DateTime.Now,
                            OptimizedTime = DateTime.Now,
                            OptitimisticTime = DateTime.Now,
                            Module = "Management",
                            Points = 8,
                            CompletionTime = null
                        },
                         new Models.Task
                         {
                             TaskId = 8,
                             TaskTitle = "Dummy Task",
                             TaskDescription = "Dummy task has no descriptions",
                             Createdon = DateTime.Now,
                             Createdby = 1,
                             AssignedById = 1,
                             AssingedToId = 2,
                             assingedby = context.employe.Find(1),
                             assingedto = context.employe.Find(2),
                             Type = "Bug",
                             Status = "Ongoing",
                             StatusDescription = "Ongoing",
                             ProjectId = 2,
                             project = context.project.Find(2),
                             Priority = "High",
                             StartDate = DateTime.Now,
                             Deleted = false,
                             LazyTime = DateTime.Now,
                             OptimizedTime = DateTime.Now,
                             OptitimisticTime = DateTime.Now,
                             Module = "Management",
                             Points = 8,
                             CompletionTime = null
                         }, new Models.Task
                         {
                             TaskId = 9,
                             TaskTitle = "Dummy Task",
                             TaskDescription = "Dummy task has no descriptions",
                             Createdon = DateTime.Now,
                             Createdby = 1,
                             AssignedById = 1,
                             AssingedToId = 2,
                             assingedby = context.employe.Find(1),
                             assingedto = context.employe.Find(2),
                             Type = "Bug",
                             Status = "Ongoing",
                             StatusDescription = "Ongoing",
                             ProjectId = 2,
                             project = context.project.Find(2),
                             Priority = "High",
                             StartDate = DateTime.Now,
                             Deleted = false,
                             LazyTime = DateTime.Now,
                             OptimizedTime = DateTime.Now,
                             OptitimisticTime = DateTime.Now,
                             Module = "Management",
                             Points = 8,
                             CompletionTime = null
                         }, new Models.Task
                         {
                             TaskId = 10,
                             TaskTitle = "Dummy Task",
                             TaskDescription = "Dummy task has no descriptions",
                             Createdon = DateTime.Now,
                             Createdby = 1,
                             AssignedById = 1,
                             AssingedToId = 2,
                             assingedby = context.employe.Find(1),
                             assingedto = context.employe.Find(2),
                             Type = "Bug",
                             Status = "Ongoing",
                             StatusDescription = "Ongoing",
                             ProjectId = 2,
                             project = context.project.Find(2),
                             Priority = "High",
                             StartDate = DateTime.Now,
                             Deleted = false,
                             LazyTime = DateTime.Now,
                             OptimizedTime = DateTime.Now,
                             OptitimisticTime = DateTime.Now,
                             Module = "Management",
                             Points = 8,
                             CompletionTime = null
                         }, new Models.Task
                         {
                             TaskId = 11,
                             TaskTitle = "Dummy Task",
                             TaskDescription = "Dummy task has no descriptions",
                             Createdon = DateTime.Now,
                             Createdby = 1,
                             AssignedById = 1,
                             AssingedToId = 2,
                             assingedby = context.employe.Find(1),
                             assingedto = context.employe.Find(2),
                             Type = "Bug",
                             Status = "Ongoing",
                             StatusDescription = "Ongoing",
                             ProjectId = 2,
                             project = context.project.Find(2),
                             Priority = "High",
                             StartDate = DateTime.Now,
                             Deleted = false,
                             LazyTime = DateTime.Now,
                             OptimizedTime = DateTime.Now,
                             OptitimisticTime = DateTime.Now,
                             Module = "Management",
                             Points = 8,
                             CompletionTime = null
                         }
                         , new Models.Task
                         {
                             TaskId = 12,
                             TaskTitle = "Dummy Task",
                             TaskDescription = "Dummy task has no descriptions",
                             Createdon = DateTime.Now,
                             Createdby = 1,
                             AssignedById = 1,
                             AssingedToId = 2,
                             assingedby = context.employe.Find(1),
                             assingedto = context.employe.Find(2),
                             Type = "Bug",
                             Status = "Ongoing",
                             StatusDescription = "Ongoing",
                             ProjectId = 2,
                             project = context.project.Find(2),
                             Priority = "High",
                             StartDate = DateTime.Now,
                             Deleted = false,
                             LazyTime = DateTime.Now,
                             OptimizedTime = DateTime.Now,
                             OptitimisticTime = DateTime.Now,
                             Module = "Management",
                             Points = 8,
                             CompletionTime = null
                         }, new Models.Task
                         {
                             TaskId = 13,
                             TaskTitle = "Dummy Task",
                             TaskDescription = "Dummy task has no descriptions",
                             Createdon = DateTime.Now,
                             Createdby = 1,
                             AssignedById = 1,
                             AssingedToId = 2,
                             assingedby = context.employe.Find(1),
                             assingedto = context.employe.Find(2),
                             Type = "Bug",
                             Status = "Ongoing",
                             StatusDescription = "Ongoing",
                             ProjectId = 2,
                             project = context.project.Find(2),
                             Priority = "High",
                             StartDate = DateTime.Now,
                             Deleted = false,
                             LazyTime = DateTime.Now,
                             OptimizedTime = DateTime.Now,
                             OptitimisticTime = DateTime.Now,
                             Module = "Management",
                             Points = 8,
                             CompletionTime = null
                         }, new Models.Task
                         {
                             TaskId = 14,
                             TaskTitle = "Dummy Task",
                             TaskDescription = "Dummy task has no descriptions",
                             Createdon = DateTime.Now,
                             Createdby = 1,
                             AssignedById = 1,
                             AssingedToId = 2,
                             assingedby = context.employe.Find(1),
                             assingedto = context.employe.Find(2),
                             Type = "Bug",
                             Status = "Ongoing",
                             StatusDescription = "Ongoing",
                             ProjectId = 2,
                             project = context.project.Find(2),
                             Priority = "High",
                             StartDate = DateTime.Now,
                             Deleted = false,
                             LazyTime = DateTime.Now,
                             OptimizedTime = DateTime.Now,
                             OptitimisticTime = DateTime.Now,
                             Module = "Management",
                             Points = 8,
                             CompletionTime = null
                         }, new Models.Task
                         {
                             TaskId = 15,
                             TaskTitle = "Dummy Task",
                             TaskDescription = "Dummy task has no descriptions",
                             Createdon = DateTime.Now,
                             Createdby = 1,
                             AssignedById = 1,
                             AssingedToId = 2,
                             assingedby = context.employe.Find(1),
                             assingedto = context.employe.Find(2),
                             Type = "Bug",
                             Status = "Ongoing",
                             StatusDescription = "Ongoing",
                             ProjectId = 2,
                             project = context.project.Find(2),
                             Priority = "High",
                             StartDate = DateTime.Now,
                             Deleted = false,
                             LazyTime = DateTime.Now,
                             OptimizedTime = DateTime.Now,
                             OptitimisticTime = DateTime.Now,
                             Module = "Management",
                             Points = 8,
                             CompletionTime = null
                         }

                    );
                context.SaveChanges();
                context.leave.AddOrUpdate(
                    new Models.Leave { Description = "Leave for Mother Illness", LeaveId = 1, EmployeId = 2, employe = context.employe.Find(2), startTime = DateTime.Now, endTime = tempdate.Add(TimeSpan.FromDays(6)), IsAccepted = false, TotalDays = 6 },
                    new Models.Leave { Description = "Leave for Mother Illness", LeaveId = 2, EmployeId = 2, employe = context.employe.Find(2), startTime = DateTime.Now, endTime = tempdate.Add(TimeSpan.FromDays(6)), IsAccepted = true, TotalDays = 6 }
                    );
                context.SaveChanges();
                context.attendance.AddOrUpdate(
                    new Models.Attendance { AttendanceId = 1, EmployeId = 1, employe = context.employe.Find(1), ForDay = DateTime.Parse("2/12/2020"), InTime = DateTime.Parse("2/12/2020 08:00 AM"), OutTime = DateTime.Parse("2/12/2020 05:15 PM"), IsDeleted = false, Status = "Present" },
                    new Models.Attendance { AttendanceId = 2, EmployeId = 1, employe = context.employe.Find(1), ForDay = DateTime.Parse("2/13/2020"), InTime = null, OutTime = null, IsDeleted = false, Status = "Absent" },
                    new Models.Attendance { AttendanceId = 3, EmployeId = 2, employe = context.employe.Find(2), ForDay = DateTime.Parse("2/12/2020"), InTime = DateTime.Parse("2/12/2020 08:00 AM"), OutTime = DateTime.Parse("2/12/2020 05:15 PM"), IsDeleted = false, Status = "Present" },
                    new Models.Attendance { AttendanceId = 4, EmployeId = 2, employe = context.employe.Find(2), ForDay = DateTime.Parse("2/13/2020"), InTime = DateTime.Parse("2/13/2020 08:00 AM"), OutTime = DateTime.Parse("2/13/2020 05:15 PM"), IsDeleted = false, Status = "Present" }
                    );
                context.SaveChanges();
                context.holiday.AddOrUpdate(
                    new Models.Holiday { CreatedBy = 1, CreatedOn = DateTime.Now, HolidayDate = tempdate.Add(TimeSpan.FromDays(1)), HolidayId = 1, HolidayName = "Pakistan Day", IsDeleted = false }
                    );
                context.SaveChanges();
                context.loan.AddOrUpdate(
                    new Models.Loan { LoanId = 1, CreatedBy = 2, CreatedOn = DateTime.Now, DateStartLoan = DateTime.Now, DateEndLoan = tempdate.Add(TimeSpan.FromDays(365)), EmployeId = 2, employe = context.employe.Find(2), RequestDate = DateTime.Now, RequestAmount = 200000, AllotedAmount = 150000, ReductionAmount = 10, IsFinished = false, IsDeleted = false, Remaining = 150000, Accepted = true }
                    );
                context.SaveChanges();
                context.invoice.AddOrUpdate(
                    new Models.Invoice { CreatedBy = 1, CreatedOn = DateTime.Now, employe = context.employe.Find(1), EmployeId = 1, ForMonth = DateTime.Parse("1/1/2020"), InvoiceId = 1, IsDeleted = false,FromMonth = DateTime.Parse("1/1/2020"), ToMonth= (DateTime.Parse("1/1/2020").Add(TimeSpan.FromDays(30))),Salary=50000,NetSalary=50500,Deduction =500,Earning=1000 },
                    new Models.Invoice { CreatedBy = 1, CreatedOn = DateTime.Now, employe = context.employe.Find(2), EmployeId = 2, ForMonth = DateTime.Parse("1/1/2020"), InvoiceId = 2, IsDeleted = false, FromMonth = DateTime.Parse("1/1/2020"), ToMonth = (DateTime.Parse("1/1/2020").Add(TimeSpan.FromDays(30))),Salary=20000,NetSalary=20000, Deduction = 0, Earning = 0 },
                    new Models.Invoice { CreatedBy = 1, CreatedOn = DateTime.Now, employe = context.employe.Find(1), EmployeId = 1, ForMonth = DateTime.Now, InvoiceId = 3, IsDeleted = false, FromMonth = DateTime.Now, ToMonth = (DateTime.Now.Add(TimeSpan.FromDays( 30))),Salary=50000,NetSalary=50000, Deduction = 0, Earning = 0 },
                    new Models.Invoice { CreatedBy = 1, CreatedOn = DateTime.Now, employe = context.employe.Find(2), EmployeId = 2, ForMonth = DateTime.Now, InvoiceId = 4, IsDeleted = false, FromMonth = DateTime.Now, ToMonth = (DateTime.Now.Add(TimeSpan.FromDays( 30))),Salary=20000,NetSalary=20000, Deduction = 0, Earning = 0 }
                    );
                context.SaveChanges();
                context.earning.AddOrUpdate(
                    new Models.Earning { EmployeId = 1, employe = context.employe.Find(1), ComName = "Bonus for function", Amount = 1000, EarningId = 1, CreatedBy = 1, CreatedOn = DateTime.Now, IsDeleted = false ,ForMonth = DateTime.Parse("1/1/2020") }
                    );
                context.SaveChanges();
                context.deduction.AddOrUpdate(
                    new Models.Deduction { ComName = "Fine", IsDeleted = false, Amount = 500, EmployeId = 1, employe = context.employe.Find(1), DeductionId = 1, CreatedOn = DateTime.Now, CreatedBy = 1, ForMonth = DateTime.Parse("1/1/2020") }
                    );
                context.SaveChanges();

            }
            catch (DbEntityValidationException ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
