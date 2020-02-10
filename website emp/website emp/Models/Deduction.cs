﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class Deduction
    {
        [Key]
        public long DeductionId { get; set; }
        public string ComName { get; set; }
        public string Amount { get; set; }
        public long salaryslipid { get; set; }
        public virtual SalarySlip salaryslip { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool? IsDeleted { get; set; }
    }
}