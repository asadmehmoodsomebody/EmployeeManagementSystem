using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class task
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskDensity { get; set; } //set through programming
        public virtual department Department { get; set; }
        public virtual project Project { get; set; }
        public virtual ICollection< groupTask> GroupTask { get; set; }
        public virtual ICollection<userTask> UserTask { get; set; }
    }
}