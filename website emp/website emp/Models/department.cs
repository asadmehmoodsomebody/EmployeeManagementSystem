using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class department
    {
        [Key]
        public int DepartmentId {get;set; }
        [Required]
        public string DepartmentName { get; set; }
        public virtual ICollection<user> Users { get; set; }


    }
}