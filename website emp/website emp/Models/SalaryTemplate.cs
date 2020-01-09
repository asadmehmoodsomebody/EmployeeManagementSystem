using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class salaryTemplate
    {
        [Key]
        public int SalaryTemplateId { get; set; }
        [Required]
        public virtual designation Designation { get; set; }
        [Required]
        public virtual department Department { get; set; }
        [Required]
        public float Amount { get; set; }
        [Range(0,100)]
        public double AbsentieDeductionPercentage { get; set; }
        [Range(0,100)]
        public double LoanDeductionPercentage { get; set; }

    }
}