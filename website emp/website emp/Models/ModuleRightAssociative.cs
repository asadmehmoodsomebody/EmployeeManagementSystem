using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class ModuleRightAssociative
    {
        [Key]
        public int ModuleRightId { get; set; }
        //index 1 foreign key
        public int ModuleId { get; set; }
        //index 2 foreign key
        public int RightId { get; set; }
        public int Createdby { get; set; }
        public DateTime Createdon { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool Deleted { get; set; }
    }
}