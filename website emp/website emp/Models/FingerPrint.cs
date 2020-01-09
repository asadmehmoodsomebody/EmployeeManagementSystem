using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class fingerPrint
    {
        [Key]
        public int FingerPrintId { get; set; }
        [Required]
        public virtual user User { get; set; }
        [Required]
        public string FingerPrintPath { get; set; }
    }
}