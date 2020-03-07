using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class Increment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IncreamentId { get; set; }
        public DateTime? IncrementedOn { get; set; }
        public string IncrementDescription { get; set; }
        public long Amount { get; set; }
        public long EmployeId { get; set; }
        public virtual Employe employe {get;set;}
        public long? ModifiedBy { get; set; }
        public DateTime? Modifiedon { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }
    }
}