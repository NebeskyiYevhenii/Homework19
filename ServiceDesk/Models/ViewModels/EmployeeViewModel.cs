using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        //public int DepartmentId { get; set; }
        public DepartmentViewModel Department { get; set; }
    }
}
