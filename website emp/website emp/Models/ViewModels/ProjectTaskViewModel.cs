using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models.ViewModels
{
    public class ProjectTaskViewModel
    {
        public Project project { get; set; }
        public Department department { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
        public Employe employe { get; set; }
    }
}