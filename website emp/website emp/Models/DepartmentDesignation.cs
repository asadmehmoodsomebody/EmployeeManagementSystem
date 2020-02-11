﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class DepartmentDesignation
    {
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long DepartmentDesignationId { get; set; }
        public long DepartmentId { get; set; }
        public long DesignationId { get; set; }
        public long EmployeId { get; set; }
        public virtual Department department { get; set; }
        public virtual Designation designation { get; set; }
        public virtual Employe employe { get; set; }
        public virtual SalaryTemplate salarytemplate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool? IsDeleted { get; set; }
    }
}