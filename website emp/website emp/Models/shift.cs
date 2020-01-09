using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class shift
    {
        [Key]
        public int ShiftId { get; set; }
        public string ShiftName { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StratDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        public virtual ICollection< user> User { get; set; }
    }
}