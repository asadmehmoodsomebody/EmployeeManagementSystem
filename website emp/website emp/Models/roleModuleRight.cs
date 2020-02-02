using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class RoleModuleRight
    {
        public int RoleModulueRightId { get; set; }
        public int RoleId { get; set; }
        public int ModuleRightId { get; set; }

        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}