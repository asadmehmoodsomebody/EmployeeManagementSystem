using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class SecurityKey
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string UserName {get;set;}
        [Required]
        public string Password { get; set; }
    }
}