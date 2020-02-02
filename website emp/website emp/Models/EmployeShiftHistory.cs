using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models
{
    public class EmployeShiftHistory
    {
        /// <summary>
        /// will keep the record of every employe shift
        /// </summary>
        public int EmployeShiftHistoryId { get; set; }
        public int EmployeId { get; set; }
        public int ShiftId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}