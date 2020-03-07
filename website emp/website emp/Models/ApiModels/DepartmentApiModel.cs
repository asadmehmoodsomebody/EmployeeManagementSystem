using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models.ApiModels
{
    public class DepartmentApiModel
    {
        
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool? IsDeleted { get; set; }
    }
}