using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class role
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public string Role { get; set; }
        public virtual ICollection<userRole> userrole { get; set; }
        public virtual ICollection<roleModuleRight> RoleModuleRight { get; set; }
    }
}