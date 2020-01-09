using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime OptimisticEndTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime PesimisticEndTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CompeletionTime { get; set; }
        public virtual department Department { get; set; }
        public virtual user User { get; set; }
        public bool Completed { get; set; }
    }
}