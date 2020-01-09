using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_emp.Models
{
    public class leaveRequest
    {
        [Key]
        public int LeaveRequestId { get; set; }
        public virtual user User { get; set; }
        [Required]
        [StringLength(maximumLength:200,MinimumLength =20)]
        public string Reason { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        public virtual status Status { get; set; }
        public bool CompletionFlag { get; set; }
    }
}