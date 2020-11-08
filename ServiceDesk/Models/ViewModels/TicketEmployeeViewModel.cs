using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Models.ViewModels
{
    public class TicketEmployeeViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int DepartmentId { get; set; }
        public TicketDepartmentViewModel TicketDepartment { get; set; }
    }
}
