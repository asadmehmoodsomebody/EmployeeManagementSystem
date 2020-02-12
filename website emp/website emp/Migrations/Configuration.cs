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
                
                   context.counter.AddOrUpdate(
                  new Models.MentainanceCounter() {MaintainanceCounterId=1, Count = 0, TableName = "Attendance" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 2, Count = 0, TableName = "Deduction" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 3, Count = 2, TableName = "Department" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 4, Count = 2, TableName = "Designation" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 5, Count = 4, TableName = "DepartmentDesignation" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 6, Count = 0, TableName = "Earning" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 7, Count = 2, TableName = "Employe" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 8, Count = 0, TableName = "EmployeModuleRight" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 9, Count = 3, TableName = "EmployeRole" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 10, Count = 0, TableName = "FingerPrint" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 11, Count = 0, TableName = "Holiday" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 12, Count = 0, TableName = "Increment" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 13, Count = 0, TableName = "Leave" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 14, Count = 0, TableName = "Loan" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 15, Count = 0, TableName = "Module" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 16, Count = 0, TableName = "ModuleRight" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 17, Count = 0, TableName = "Project" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 18, Count = 0, TableName = "Right" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 19, Count = 2, TableName = "Role" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 20, Count = 0, TableName = "RoleModuleRight" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 21, Count = 0, TableName = "SalarySlip" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 22, Count = 1, TableName = "SalaryTemplate" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 23, Count = 2, TableName = "Shift" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 24, Count = 0, TableName = "Task" }
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
                     new Models.Shift { CreatedBy = 1,ShiftName="Morning", CreatedOn = DateTime.Now, IsDeleted = false, ShiftId = 1, ShiftStartTime = DateTime.Parse("2/12/2020 08:00 AM"), ShiftEndTime = DateTime.Parse("2/12/2020 05:00 PM") },
                     new Models.Shift { CreatedBy = 1,ShiftName="Evening", CreatedOn = DateTime.Now, IsDeleted = false, ShiftId = 2, ShiftStartTime = DateTime.Parse("2/12/2020 06:00 PM"), ShiftEndTime = DateTime.Parse("3/12/2020 03:00 AM") }
                     );
                 context.SaveChanges();
                 context.departmentdesignation.AddOrUpdate(
                     new Models.DepartmentDesignation { CreatedBy = 1, CreatedOn = DateTime.Now, DepartmentId = 1, DesignationId = 1, DepartmentDesignationId = 1, IsDeleted = false,department=context.department.Find(1),designation=context.designation.Find(1) },
                     new Models.DepartmentDesignation { CreatedBy = 1, CreatedOn = DateTime.Now, DepartmentId = 1, DesignationId = 2, DepartmentDesignationId = 2, IsDeleted = false, department = context.department.Find(1), designation = context.designation.Find(2) },
                     new Models.DepartmentDesignation { CreatedBy = 1, CreatedOn = DateTime.Now, DepartmentId = 2, DesignationId = 1, DepartmentDesignationId = 3, IsDeleted = false, department = context.department.Find(2), designation = context.designation.Find(1) },
                     new Models.DepartmentDesignation { CreatedBy = 1, CreatedOn = DateTime.Now, DepartmentId = 2, DesignationId = 2, DepartmentDesignationId = 4, IsDeleted = false, department = context.department.Find(2), designation = context.designation.Find(2) }
                     );
                 context.SaveChanges();
                  context.role.AddOrUpdate(
                         new Models.Role { RoleId = 1, RoleName = "Admin", CreatedBy = 1, CreatedOn = DateTime.Now, IsDeleted = false },
                         new Models.Role { RoleId = 2, RoleName = "User", CreatedBy = 1, CreatedOn = DateTime.Now, IsDeleted = false }
                         );
                  context.SaveChanges();
                  context.salarytemplate.AddOrUpdate(
                      new Models.SalaryTemplate { CreatedBy = 1,TemplateName="FirstTemp", CreatedOn = DateTime.Now, IsDeleted = false,Payroll=10000,SalaryTemplateId=1}
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
                                          Gender="Male",
                                          Relegion = "Islam",
                                          Picture = "dummy",
                                          Education = "MCS",
                                          SalaryTemplateId = 1,
                                          salarytemplate = context.salarytemplate.Find(1),
                                          shift = context.shift.Find(1),
                                          departmentdesignation = null,
                                          department = context.department.Find(1)
                                      }, new Models.Employe
                                         {
                                             EmployeId = 2,
                                             IsDeleted = false,
                                             CreatedBy = 1,
                                             CreatedOn = DateTime.Now,
                                             Address = "Pabbi",
                                             Departmentid = 1,
                                             DOB = DateTime.Now,
                                             Gender="Male",
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
                                             SalaryTemplateId = 1,
                                             salarytemplate = context.salarytemplate.Find(1),
                                             shift = context.shift.Find(1),
                                             departmentdesignation=null,
                                             department=context.department.Find(1)
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
                                             employe=context.employe.Find(1),
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
                        AssignedBy = 1,
                        AssingedTo = 1,
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
                         AssignedBy = 1,
                         AssingedTo = 2,
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
                          AssignedBy = 1,
                          AssingedTo = 2,
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
                           AssignedBy = 1,
                           AssingedTo = 2,
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
            }
            catch (DbEntityValidationException ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
