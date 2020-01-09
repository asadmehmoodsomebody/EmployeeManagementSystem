using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class loanInstallment
    {
        [Key]
        public int LoanInstallmentId { get; set; }
        public virtual loanRequest LoanRequest { get; set; }
        public double TotalAmount { get; set; }
        public double Paid { get; set; }
    }
}