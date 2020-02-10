﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class EmployeModuleRight
    {
        [Key]
        public long EmployeModuleRightId { get; set; }
        public long ModuleRightId { get; set; }
        public long EmployeId { get; set; }
        public virtual ModuleRight moduleright { get; set; }
        public virtual Employe employe { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool? IsDeleted { get; set; }
    }
}