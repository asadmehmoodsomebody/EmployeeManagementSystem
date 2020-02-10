using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class SalarySlip
    {
        [Key]
        public long SalarySlipId { get; set; }
        public DateTime? ForMonth { get; set; }
        public long EmployeId { get; set; }
        public virtual Employe employe { get; set; }
        public virtual ICollection< Deduction> deduction { get; set; }
        public virtual ICollection<Earning> earning { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool? IsDeleted { get; set; }
    }
}