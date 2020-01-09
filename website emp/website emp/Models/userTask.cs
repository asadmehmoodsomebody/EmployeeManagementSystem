using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class userTask
    {
        [Key]
        public int UserTaskId { get; set; } 
        public virtual user User { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime PesimisticTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime OptimisticTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EndtDate { get; set; }

        public virtual task Task { get; set; }
        public bool Completed { get; set; }
    }
}