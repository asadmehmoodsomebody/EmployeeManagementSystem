using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class Employe
    {
        [Key]
        public int EmployeId { get; set; }
        public string EmployeName { get; set; }
        public string EmployePassword { get; set; }
        public string EmployePhone { get; set; }
        public string EmployePhysicalAddress { get; set; }
        public string EmployeMailingAddress { get; set; }
        public int DepartmentId { get; set; }
        public string EmployePicture { get; set; }
        public string EmployeCNIC { get; set; }
        public string EmployeEducation { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
     }
}