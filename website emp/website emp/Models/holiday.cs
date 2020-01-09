using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace website_emp.Models
{
    public class holiday
    {
        [Key]
        public int HolidayId { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime HolidayDateTime { get; set;}
        [Required]
        public string Description { get; set; }
           
    }
}