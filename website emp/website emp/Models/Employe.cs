using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class Employe
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EmployeId { get; set; }
        [StringLength(maximumLength: 150)]
        [Required]
        //unique
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [StringLength(maximumLength: 200, MinimumLength = 5, ErrorMessage = "MjnimumLength is 5")]
        public string Password { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Education { get; set; }
        public string Picture { get; set; }
        public DateTime? DOB { get; set; }
        public bool? IsMarried { get; set; }
        public string Relegion { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AboutMe { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public long Departmentid { get; set; }
        public virtual Department department { get; set; }
        public long Designationid { get; set; }
        public virtual Designation designation { get; set; }
        public virtual ICollection<Increment> increments { get; set; }
        public virtual ICollection<EmployeRole> employerole {get;set;}
        public virtual ICollection<EmployeModuleRight> moduleright { get; set; }
        public virtual ICollection<Deduction> deduction { get; set; }
        public virtual ICollection<Earning> earning { get; set; }
        public virtual ICollection<Task> task { get; set; }
        public long ShiftId { get; set; }
        public virtual Shift shift { get; set; }
        public virtual ICollection<Leave> leave { get; set; }
        public virtual ICollection<Attendance> attendance { get; set; }
        public virtual FingerPrint fingerprint { get; set; }
        public virtual ICollection<Invoice> invoice { get; set; }
        public string Gender { get; set; }
        public string EmployeType { get; set; }
        public double Salary { get; set; }
    }
}