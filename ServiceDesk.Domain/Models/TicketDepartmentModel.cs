using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Domain.Models
{
    public class TicketDepartmentModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<TiketModel> Tickets { get; set; }
        public ICollection<TicketEmployeeModel> TicketEmployees { get; set; }
    }
}
