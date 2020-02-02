﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class Deduction
    {
        public int DeductionId { get; set; }
        public int SalarySlip { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public double Amount { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}