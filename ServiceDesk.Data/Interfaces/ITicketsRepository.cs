using ServiceDesk.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Data.Interfaces
{
    public interface ITicketsRepository
    {
        IEnumerable<Ticket> GetAll();

        Ticket CreateTicket(Ticket model);

        Ticket GetById(int id);
    }
}
