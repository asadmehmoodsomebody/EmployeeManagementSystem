using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models.ApiModels
{
    public class GeneratePaySlipApiModel
    {
        public long EmployeId { get; set; }
        public string EmployeName { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
        public DateTime? fromdate { get; set; }
        public DateTime? todate { get; set; }
    }
}