using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Models.ViewModels
{
    public class DepartmentViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<TicketViewModel> Tickets { get; set; }
        public ICollection<EmployeeViewModel> Employees { get; set; }
    }
}
