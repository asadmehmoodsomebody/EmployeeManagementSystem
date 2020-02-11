using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class SalaryTemplate
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SalaryTemplateId { get; set; }
        public long Payroll { get; set; }
        public virtual DepartmentDesignation departmentdesignation { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool? IsDeleted { get; set; }
    }
}