using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class Shift
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShiftId { get; set; }
        public DateTime? ShiftStartTime { get; set; }
        public string ShiftName { get; set; }
        public DateTime? ShiftEndTime { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool? IsDeleted { get; set; }
        public virtual ICollection<Employe> employe { get; set; }
    }
}