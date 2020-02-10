using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class Role
    {
        [Key]
        public long RoleId { get; set; }
        [Required]
        [StringLength(maximumLength:150)]
        public string RoleName { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool? IsDeleted { get; set; }
        public ICollection<EmployeRole> employerole { get; set; }
        public ICollection<RoleModuleRight> rolemoduleright { get; set; }
    }
}