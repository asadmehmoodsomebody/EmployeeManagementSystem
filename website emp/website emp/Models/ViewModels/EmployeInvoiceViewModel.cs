﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models.ViewModels
{
    public class EmployeInvoiceViewModel
    {
        public Employe employe { get; set; }
        public List<Invoice> invoice { get; set; } 
    }
}