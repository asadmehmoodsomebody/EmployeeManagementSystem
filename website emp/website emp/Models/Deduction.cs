using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class deduction
    {
        [Key]
        public int DeductionId { get; set; }
        [Required]
        public virtual paySlip PaySlip { get; set; }
    }
}