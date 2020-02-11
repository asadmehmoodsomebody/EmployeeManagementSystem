using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class Loan
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long LoanId { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? DateStartLoan { get; set; }
        public  DateTime? DateEndLoan { get; set; }
        public double RequestAmount { get; set; }
        public double AllotedAmount { get; set; }
        public double ReductionAmount { get; set; }
        public double Remaining { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool? IsDeleted { get; set; }
        public long EmployeId { get; set; }
        public Employe employe { get; set; }
        public bool? IsFinished { get; set; }
    }
}