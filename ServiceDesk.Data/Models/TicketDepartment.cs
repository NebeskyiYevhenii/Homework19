using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Data.Models
{
    public class TicketDepartment
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<TicketEmployee> TicketEmployees { get; set; }
    }
}
