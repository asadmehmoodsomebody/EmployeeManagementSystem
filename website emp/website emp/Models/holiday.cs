using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class Holiday
    {
        public int HolidayId { get; set; }
        public string HolidayName { get; set; }
        public string HolidayDescription {get;set;}
        public DateTime HolidayStartDate { get; set; }
        public DateTime HolidayEndTime { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}