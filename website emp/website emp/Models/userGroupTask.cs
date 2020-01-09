using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class userGroupTask
    {
        [Key]
        public int UserGroupTaskId { get; set; }
        public virtual user User { get; set; }
        public virtual groupTask GroupTask { get; set; }
        public string Status { get; set; }
    }
}