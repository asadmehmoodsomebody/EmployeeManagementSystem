namespace website_emp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<website_emp.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(website_emp.Models.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //context.department.AddOrUpdate(
            //       new Models.Department() { DepartmentName = "IT",DepartmentId=1, Modifiedon = DateTime.Now, DepartmentDesciption="Include Members related to IT",Deleted=false, Createdon=DateTime.Now,Createdby=1 },
            //       new Models.Department() { DepartmentName = "Management",DepartmentId=2, Modifiedon = DateTime.Now, Createdby = 1, Createdon = DateTime.Now, DepartmentDesciption = "Include Members related to Management", Deleted = false }
            //    );
            //context.designation.AddOrUpdate(
            //    new Models.Designation() {DesignationId=1, DesignationName = "Manager", Createdby = 1, Modifiedon = DateTime.Now, Createdon = DateTime.Now, DesignationDesciption = "This is the head", Deleted = false },
            //     new Models.Designation() {DesignationId=2, DesignationName = "HR", Modifiedon = DateTime.Now, Createdby = 1, Createdon = DateTime.Now, DesignationDesciption = "This is the Human Resource", Deleted = false }
            //    );
            //context.employe.AddOrUpdate(
            //    new Models.Employe() { UserName = "Asad_don", CNIC = "17201-7439433-5", Modifiedon = DateTime.Now, Createdby = 1, Createdon = DateTime.Now, DepartmentId = 1, Picture = "dummy1", FirstName = "Asad", LastName = "Mehmood", Education = "MCS", IsActive = true, PhysicalAddress = "Sultan Garhi Risalpur Cantt", MailingAddress = "Risalpur Cantt Nowshera", EmailAddress = "Asad7121208@gmail.com", IsDeleted = false, EmployeId = 1, Password = "admin", Phone = "03329967756",Gender="M" },
            //     new Models.Employe() { UserName = "Zia_don", CNIC = "17201-7439433-5", Modifiedon = DateTime.Now, Createdby = 1, Createdon = DateTime.Now, DepartmentId = 1, Picture = "dummy2", FirstName = "Zia", LastName = "ur Rehman", Education = "MCS", IsActive = true, PhysicalAddress = "Toru Mardan", MailingAddress = "Toru mayaar Mardan", EmailAddress = "Asad7121208@gmail.com", IsDeleted = false, EmployeId = 2, Password = "employe", Phone = "03329967756",Gender="M" }
            //     );
            //context.departmentdesignationassociative.AddOrUpdate(
            //    new Models.DepartmentDesignationAssociative() { Deleted = false, DepartmentId = 1, DesignationId = 1, DepartmentDesignationAssociativeId = 1 },
            //    new Models.DepartmentDesignationAssociative() { Deleted = false, DepartmentId = 1, DesignationId = 2, DepartmentDesignationAssociativeId = 2 }
            //    );
            //context.employedepartmentdesignation.AddOrUpdate(
            //    new Models.EmployeDepartmentDesignation() { DepartmentDesignationId = 1, EmployeId = 1, EmployeDepartmentDesignationId = 1 }
            //    );
            //context.role.AddOrUpdate(
            //    new Models.Role() { RoleId=1,Createdby=1,Createdon=DateTime.Now,Deleted=false,RoleName="Super Admin", Modifiedon = DateTime.Now },
            //    new Models.Role() { RoleId = 2, Createdby = 1,Modifiedon= DateTime.Now, Createdon = DateTime.Now, Deleted = false, RoleName = "Admin" }
            //    );
            //context.employerole.AddOrUpdate(
            //    new Models.EmployeRole() { EmployeId = 1, EmployeRoleId = 1, RoleId = 1 },
            //    new Models.EmployeRole { EmployeId=1,EmployeRoleId=2,RoleId=2}
            //    );
            //context.project.AddOrUpdate(
            //    new Models.Project() {ProjectId=1,Createdby=1, Modifiedon = DateTime.Now, Createdon=DateTime.Now,Deleted=false,ProjectTitle="EMS",DepartmentId=1,ProjectDescription="Manage the employes",StartDate=DateTime.Now,EndDate=DateTime.Parse("2/2/2021") }
            //    );
            //context.task.AddOrUpdate(
            //    new Models.Task
            //    {
            //        TaskId = 1,
            //        AssignedBy = 1,
            //        AssingedTo = 2,
            //        Createdby = 1,
            //        Createdon = DateTime.Now,
            //        Deleted = false,
            //        Points = 100,
            //        Priority = "High",
            //        ProjectId = 1,
            //        TaskTitle = "Create the BackEnd of EMS",
            //        Status = "Pending",
            //        StatusDescription = "Pending",
            //        TaskDescription = "Bangash isse jaldi kar",
            //        OptitimisticTime = DateTime.Parse("2/8/2020"),
            //        OptimizedTime = DateTime.Parse("2/8/2020"),
            //        LazyTime = DateTime.Parse("2/8/2020"),
            //        StartDate = DateTime.Now,
            //        Modifiedon = DateTime.Now
            //    }
            //    );
            
                   context.counter.AddOrUpdate(
                  new Models.MentainanceCounter() {MaintainanceCounterId=1, Count = 0, TableName = "Attendance" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 2, Count = 0, TableName = "Deduction" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 3, Count = 0, TableName = "Department" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 4, Count = 0, TableName = "Designation" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 5, Count = 0, TableName = "DepartmentDesignation" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 6, Count = 0, TableName = "Earning" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 7, Count = 0, TableName = "Employe" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 8, Count = 0, TableName = "EmployeModuleRight" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 9, Count = 0, TableName = "EmployeRole" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 10, Count = 0, TableName = "FingerPrint" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 11, Count = 0, TableName = "Holiday" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 12, Count = 0, TableName = "Increment" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 13, Count = 0, TableName = "Leave" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 14, Count = 0, TableName = "Loan" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 15, Count = 0, TableName = "Module" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 16, Count = 0, TableName = "ModuleRight" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 17, Count = 0, TableName = "Project" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 18, Count = 0, TableName = "Right" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 19, Count = 0, TableName = "Role" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 20, Count = 0, TableName = "RoleModuleRight" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 21, Count = 0, TableName = "SalarySlip" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 22, Count = 0, TableName = "SalaryTemplate" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 23, Count = 0, TableName = "Shift" },
                  new Models.MentainanceCounter() { MaintainanceCounterId = 24, Count = 0, TableName = "Task" }
                 );
                 /* 
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
                   context.role.AddOrUpdate(
                       new Models.Role { RoleId = 1, RoleName = "Admin", CreatedBy = 1, CreatedOn = DateTime.Now, IsDeleted = false },
                       new Models.Role { RoleId = 2, RoleName = "User", CreatedBy = 1, CreatedOn = DateTime.Now, IsDeleted = false }
                       );
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
                           Email = "Asad7121208@hotmail.com",
                           IsMarried = false,
                           FirstName = "Asad",
                           LastName = "Mehmood",
                           IsActive = true,
                           Password = "hunter001",
                           UserName = "Asad_hunter",
                           ShiftId = 1,
                           Relegion = "Islam",
                           Picture = "dummy",
                           Education = "MCS"
                       }, new Models.Employe
                       {
                           EmployeId = 2,
                           IsDeleted = false,
                           CreatedBy = 1,
                           CreatedOn = DateTime.Now,
                           Address = "Pabbi",
                           Departmentid = 1,
                           DOB = DateTime.Now,
                           Email = "Asad7121208@hotmail.com",
                           IsMarried = false,
                           FirstName = "Muhammad",
                           LastName = "Ismail",
                           IsActive = true,
                           Password = "user",
                           UserName = "ismail_user",
                           ShiftId = 1,
                           Relegion = "Islam",
                           Picture = "dummy1",
                           Education = "MCS"
                       }
                       );
                   context.employerole.AddOrUpdate(
                       new Models.EmployeRole
                       {
                           CreatedOn = DateTime.Now,
                           CreatedBy = 1,
                           EmployeId = 1,
                           EmployeRoleId = 1,
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
                           IsDeleted = false
                       },
                       new Models.EmployeRole
                       {
                           CreatedOn = DateTime.Now,
                           CreatedBy = 1,
                           EmployeId = 2,
                           EmployeRoleId = 3,
                           RoleId = 2,
                           IsDeleted = false
                       }
                       );

                   context.SaveChanges();
               }catch (Exception ex) { }*/

        }
    }
}
