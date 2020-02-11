using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class FingerPrint
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long FingerPrintId { get; set; }
        public string Fingerprint { get; set; }
        public virtual Employe employe { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? Modifiedon { get; set; }
        public bool? IsDeleted { get; set; }
    }
}