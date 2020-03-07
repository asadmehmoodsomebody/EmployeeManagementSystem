using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class LoanInstallment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long InstallmentId { get; set; }
        public long LoanId { get; set; }
        public virtual Loan loan { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool? IsDeleted { get; set; }
        public double Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidOn { get; set; }
    }
}