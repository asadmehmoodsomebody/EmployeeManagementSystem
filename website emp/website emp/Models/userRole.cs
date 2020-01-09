using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class userRole
    {
        [Key]
        public int UserRoleId { get; set; }
        [Required]
        public virtual user User { get; set; }
        [Required]
        public virtual role Role { get; set; }
    }
}