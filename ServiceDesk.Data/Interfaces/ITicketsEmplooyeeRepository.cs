using ServiceDesk.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Data.Interfaces
{
    public interface ITicketsEmplooyeeRepository
    {
        IEnumerable<TicketEmployee> GetAll();

        TicketEmployee CreateTicketEmployee(TicketEmployee model);

        TicketEmployee GetById(int id);
    }
}
