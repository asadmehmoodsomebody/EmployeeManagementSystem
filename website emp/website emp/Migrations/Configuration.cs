namespace website_emp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<website_emp.Models.context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(website_emp.Models.context context)
        {
            context.Departments.AddOrUpdate(
                new Models.department() { DepartmentId = 1, DepartmentName = "Management" },
                new Models.department() { DepartmentId = 2, DepartmentName = "Design" },
                new Models.department() { DepartmentId = 3, DepartmentName = "IT" },
                new Models.department() { DepartmentId = 4, DepartmentName = "Sales" },
                new Models.department() { DepartmentId = 5, DepartmentName = "Marketing" }
                );
            context.SaveChanges();
            context.Designations.AddOrUpdate(
                new Models.designation() { DesignationId = 1, DesignationName = "CEO" },
                new Models.designation() { DesignationId = 2, DesignationName = "Admin Manager" },
                new Models.designation() { DesignationId = 3, DesignationName = "HR manager" },
                new Models.designation() { DesignationId = 4, DesignationName = "Sales Manager" },
                new Models.designation() { DesignationId = 5, DesignationName = "Marketing Manager" }
                );
            context.SaveChanges();
            context.States.AddOrUpdate(
                new Models.status() { StatusId = 1, State = "Pending" },
                new Models.status() { StatusId = 2, State = "Allowed" },
                new Models.status() { StatusId = 3, State = "Denied" }
                );
            context.SaveChanges();
            context.Users.AddOrUpdate(
                new Models.user() { UserId = 1, Department = context.Departments.FirstOrDefault(x => x.DepartmentName == "Management"), Designation = context.Designations.FirstOrDefault(x => x.DesignationName == "Admin Manager"),  UserName = "Tahir_Employ",Name="Tahir", Email = "Tahir71212018@gmail.com", Password = "admin", Role = "Employ", Status = context.States.FirstOrDefault(p => p.State == "Pending") },
                new Models.user() { UserId = 2, Department = context.Departments.FirstOrDefault(x => x.DepartmentName == "Management"), Designation = context.Designations.FirstOrDefault(x => x.DesignationName == "Admin Manager"), Name = "Asad", UserName = "Asad_don", Email = "Asad71212018@gmail.com", Password = "admin", Role = "Admin", Status = context.States.FirstOrDefault(p => p.State == "Allowed") },
                new Models.user() { UserId = 3, Department = context.Departments.FirstOrDefault(x => x.DepartmentName == "IT"), Designation = context.Designations.FirstOrDefault(x => x.DesignationName == "Admin Manager"), Name = "Asad", UserName = "Asad_dona", Email = "Asad7121209@gmail.com", Password = "admin", Role = "Admin", Status = context.States.FirstOrDefault(p => p.State == "Pending") },
                new Models.user() { UserId = 4, Department = context.Departments.FirstOrDefault(x => x.DepartmentName == "Marketing"), Designation = context.Designations.FirstOrDefault(x => x.DesignationName == "CEO"), Name = "Asad", UserName = "Asad_donb", Email = "Asad71212010@gmail.com", Password = "admin", Role = "Employ", Status = context.States.FirstOrDefault(p => p.State == "Denied") },
                new Models.user() { UserId = 5, Department = context.Departments.FirstOrDefault(x => x.DepartmentName == "Sales"), Designation = context.Designations.FirstOrDefault(x => x.DesignationName == "Marketing Manager"), Name = "Asad", UserName = "Asad_donc", Email = "Asad71212011@gmail.com", Password = "admin", Role = "Employ", Status = context.States.FirstOrDefault(p => p.State == "Pending") },
                new Models.user() { UserId = 6, Department = context.Departments.FirstOrDefault(x => x.DepartmentName == "Management"), Designation = context.Designations.FirstOrDefault(x => x.DesignationName == "HR Manager"), Name = "Asad", UserName = "Asad_donk", Email = "Asad712120125@gmail.com", Password = "admin", Role = "Employ", Status = context.States.FirstOrDefault(p => p.State == "Pending") },
                new Models.user() { UserId = 7, Department = context.Departments.FirstOrDefault(x => x.DepartmentName == "Design"), Designation = context.Designations.FirstOrDefault(x => x.DesignationName == "Sales Manager"), Name = "Asad", UserName = "Asad_done", Email = "Asad71212013@gmail.com", Password = "admin", Role = "Admin", Status = context.States.FirstOrDefault(p => p.State == "Denied") }
                );
            context.SaveChanges();
            context.keys.AddOrUpdate(
                new Models.SecurityKey() { ID = 1, UserName = "Asad", Password = "123" }
                );
            context.SaveChanges();
        }
    }
}
