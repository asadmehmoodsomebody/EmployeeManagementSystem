using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class right
    {
        [Key]
        public int RightId { get; set; }
        [Required]
        public string RightName { get; set; } 
        public virtual ICollection<moduleRight> ModuleRight { get; set; }
    }
}