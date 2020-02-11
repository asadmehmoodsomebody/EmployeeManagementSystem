using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class ModuleRight
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ModuleRightId { get; set; }
        public long ModuleId { get; set; }
        public long RightId { get; set; }
        public virtual Module module { get; set; }
        public virtual Right right { get; set; }
        public virtual ICollection<RoleModuleRight> rolemoduleright { get; set; }
        public virtual ICollection<EmployeModuleRight> employemoduleright { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool? IsDeleted { get; set; }
    }
}