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
        public long AssignedBy { get; set; }
        public Employe assingedby { get; set; }
        //foriegn key employe
        public long AssingedTo { get; set; }
        public Employe assingedto { get; set; }
        [StringLength(maximumLength: 100)]
        public string Priority { get; set; }
        public int Createdby { get; set; }
        public DateTime Createdon { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool Deleted { get; set; }
        public long ProjectId { get; set; }
        public Project project { get; set; }
    }
}