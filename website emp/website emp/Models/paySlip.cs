using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class paySlip
    {
        [Key]
        public int PaySlipId { get; set; }
        public double TotalEarnings { get; set; }
        public virtual user User { get; set; }
        public virtual deduction Deduction { get; set; }

    }
}