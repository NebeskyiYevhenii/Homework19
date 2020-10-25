using ServiceDesk.Data.Models;
using System.Collections.Generic;

namespace ServiceDesk.Data.Repositories
{
    public class TicketRepository
    {
        private List<Ticket> Tickets { get; set; }

        public TicketRepository()
        {
            Tickets = new List<Ticket>();
        }

        public void Create(Ticket ticket)
        {
            Tickets.Add(ticket);
        }
        public Ticket Get(int id)
        {
            return Tickets[id];
        }
    }
}
