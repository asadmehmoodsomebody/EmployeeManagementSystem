using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models.ViewModels
{
    public class InvoiceEmployeEarningDeductionViewModel
    {
       public Invoice invoice { get; set; }
        public Employe employe { get; set; }
        public IEnumerable<Deduction> deduction { get; set; }
        public IEnumerable<Earning> earning { get; set; }
    }
}