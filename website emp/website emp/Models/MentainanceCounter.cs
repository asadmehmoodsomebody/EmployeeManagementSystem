using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class MentainanceCounter
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MaintainanceCounterId { get; set; }
        [Required]
        [StringLength(maximumLength:150)]
        public string TableName { get; set; }
        public long Count { get; set; }
    }
}