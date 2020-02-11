using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class RoleModuleRight
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long RoleModuleRightId { get; set; }
        public long ModuleRightId { get; set; }
        public long RoleId { get; set; }
        public virtual Role role { get; set; }
        public virtual Employe employe {get;set;}
        public long CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool? IsDeleted { get; set; }
    }
}