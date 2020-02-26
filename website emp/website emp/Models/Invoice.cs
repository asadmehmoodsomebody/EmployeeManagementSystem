using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class Invoice
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long InvoiceId { get; set; }
        public DateTime? ForMonth { get; set; }
        public long EmployeId { get; set; }
        public virtual Employe employe { get; set; }
         public long CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool? IsDeleted { get; set; }
        public double Earning { get; set; }
        public double Deduction { get; set; }
        public double NetSalary { get; set; }
        public double Salary { get; set; }
        public DateTime? FromMonth { get; set; }
        public DateTime? ToMonth { get; set; }
    }
}