using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class user
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Fill the Name Field")]
        [StringLength(50,ErrorMessage ="Minimum 3 characters",MinimumLength =3)]
        public string Name { get; set; }
        [Required]
        [DataType (DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType (DataType.Password)]
        public string Password { get; set; }
        public virtual designation Designation { get; set; }
        public virtual department Department { get; set; }

        public virtual status Status { get; set; }

        public virtual ICollection<userRole> userrole { get; set;} 
        public virtual ICollection<userRight> UserRight { get; set; }
        public virtual shift Shift { get; set; }
        public virtual fingerPrint FingerPrint { get; set; }
        public virtual ICollection<leaveRequest> LeaveRequest { get; set; }
        public virtual ICollection<attendance> Attendance { get; set; }

        public virtual ICollection<paySlip> PaySlip { get; set; }
        public virtual ICollection<loanRequest> LoanRequest { get; set; }
        public virtual ICollection<project> Project { get; set; }
        public virtual ICollection<userGroupTask> UserGroupTask { get; set; }
        public virtual ICollection<userTask> UserTask { get; set; }
    }
}