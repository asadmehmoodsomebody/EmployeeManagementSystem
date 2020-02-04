using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class Employe
    {
        [Key]
        public long EmployeId { get; set; }
        [Required]
        [StringLength(150,ErrorMessage ="Length between 1-150",MinimumLength =5)]
        //unique
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [StringLength(200,ErrorMessage ="Length between 1-200",MinimumLength =5)]
        public string Password { get; set; }
        [StringLength(maximumLength:15)]
        public string Phone { get; set; }
        public string PhysicalAddress { get; set; }
        public string MailingAddress { get; set; }
        public string EmailAddress { get; set; }
        // foriegn key 
        public int DepartmentId { get; set; }
        public string Picture { get; set; }
        [StringLength(maximumLength:20)]
        public string CNIC { get; set; }
        public string Gender { get; set; }
        public string Education { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? Createdby { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime? Modifiedon { get; set; }
    }
}