using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class fine
    {
        [Key]
        public int FineId { get; set; }
        public virtual deduction Deduction { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; } 
    }
}