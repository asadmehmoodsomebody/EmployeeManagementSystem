using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class loanRequest
    {
        [Key]
        public int LoanRequestId { get; set; }
        public virtual user User { get; set; }
        public double Amount { get; set; }
        public bool Status { get; set; }
        public double RemainingAmount { get; set; }
        public virtual ICollection<loanInstallment> LoanInstallment { get; set; }
    }
}