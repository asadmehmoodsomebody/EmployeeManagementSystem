using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models.ViewModels
{
    public class EarningDeductionViewModel
    {
        public IEnumerable<Earning> earning { get; set; }
        public IEnumerable<Deduction> deduction { get; set; }
    }
}