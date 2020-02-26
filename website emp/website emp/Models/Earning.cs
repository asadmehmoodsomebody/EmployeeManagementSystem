using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class Earning
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EarningId { get; set;}
        public string ComName { get; set; }
        public double Amount { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool? IsDeleted { get; set; }
        public long EmployeId { get; set; }
        public Employe employe { get; set; }
        public DateTime? ForMonth { get; set; }
    }
}