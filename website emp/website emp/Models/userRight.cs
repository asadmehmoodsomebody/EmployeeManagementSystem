using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class userRight
    {
        [Key]
        public int UserRightId { get; set; }
        [Required]
        public virtual user User { get; set; }
        [Required]
        public virtual moduleRight ModuleRight { get; set; }
    }
}