using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class attendance
    {
        public int AttendanceId { get; set; }
        public virtual user User { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [Required]
        public string Status { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }
    }
}