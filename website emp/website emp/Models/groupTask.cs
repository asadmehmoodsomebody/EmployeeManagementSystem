using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class groupTask
    {
        [Key]
        public int GroupTaskId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime OptimistictTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime PesimisicTime { get; set; }
        public virtual task Task { get; set; }
        public virtual ICollection<userGroupTask> UserGroupTask { get; set; }
    }
}