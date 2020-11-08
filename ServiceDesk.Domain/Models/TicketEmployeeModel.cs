using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Domain.Models
{
    public class TicketEmployeeModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int DepartmentId { get; set; }
        public TicketDepartmentModel TicketDepartment { get; set; }
    }
}
