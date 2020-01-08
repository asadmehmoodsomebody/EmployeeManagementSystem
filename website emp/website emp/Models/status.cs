using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class status
    {
        [Key]
        public int StatusId { get; set; }
        [Required]
        public string State { get; set; }
        public virtual ICollection<user> Users { get; set; }
    }
}