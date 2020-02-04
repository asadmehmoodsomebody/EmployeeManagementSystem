using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class Right
    {
        [Key]
        public int RightId { get; set; }
        [Required]
        [StringLength(maximumLength:150)]
        //unique
        public string RightName { get; set; }
        public int Createdby { get; set; }
        public DateTime Createdon { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool Deleted { get; set; }
    }
}