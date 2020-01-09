using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class module
    {
        [Key]
        public int ModuleId { get; set; }
        [Required]
        public string ModuleName { get; set; }
        public virtual ICollection<moduleRight> ModuleRight { get; set; } 
    }
}