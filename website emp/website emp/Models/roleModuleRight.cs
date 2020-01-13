﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class roleModuleRight
    {
        [Key]
        public int RoleModuleRightId { get; set; }
        [Required]
        public virtual role Role { get; set; }
        [Required]
        public virtual moduleRight ModuleRight { get; set; }
    }
}