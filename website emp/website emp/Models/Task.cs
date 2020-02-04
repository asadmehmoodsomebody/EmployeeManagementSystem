using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class Task
    {
        [Key]
        public long TaskId { get; set; }
        //foriegn key
        public int ProjectId { get; set; }
        [StringLength(maximumLength:150)]
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime OptitimisticTime { get; set; }
        public DateTime OptimizedTime { get; set; }
        public DateTime LazyTime { get; set; }
        public int Points { get; set; }
        [StringLength(maximumLength:50)]
        public string Status { get; set; }
        public string StatusDescription { get; set; }
        //foriegn key employe
        public int AssignedBy { get; set; }
        //foriegn key employe
        public int AssingedTo { get; set; }
        [StringLength(maximumLength: 100)]
        public string Priority { get; set; }
        public int Createdby { get; set; }
        public DateTime Createdon { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool Deleted { get; set; }
    }
}