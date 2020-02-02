using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class SalaryTemplate
    {
        public int SalaryTemplateId { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
        public string TemplateName { get; set; }
        public double AmountPerHour { get; set; }
        public double AbsentiesPercentageDeduction { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}