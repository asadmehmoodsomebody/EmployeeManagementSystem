using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class moduleRight
    {
        [Key]
        public int ModuleRightId { get; set; }
        [Required]
        public virtual module Module { get; set; }
        [Required]
        public virtual right Right { get; set; }
        public virtual ICollection<roleModuleRight> RoleModuleRight { get; set; }
        public virtual ICollection<userRight> UserRight { get; set; }
    }
}