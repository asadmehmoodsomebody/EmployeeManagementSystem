using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_emp.Models.ViewModels
{
    public class ProjectTaskViewModel
    {
        public Project project { get; set; }
        public Pagination<Task> tasks { get; set; }
    }
}