﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class EmployeRole
    {
        [Key]
        public long EmployeRoleId { get; set; }
        public long RoleId { get; set; }
        public long EmployeId { get; set; }
        public virtual Role role { get; set; }
        public virtual Employe employe { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool? IsDeleted { get; set; }
    }
}