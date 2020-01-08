using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class designation
    {
        [Key]
        public int DesignationId { get; set; }
        [Required]
        public string DesignationName { get; set; }
        public virtual ICollection<user> Users { get; set; }

    }
}