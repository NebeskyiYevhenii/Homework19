using ServiceDesk.Data.Interfaces;
using ServiceDesk.Data.Models;
using System.Collections.Generic;

namespace ServiceDesk.Data.Repositories
{
    public class TicketRepositoryList : ITicketsRepository
    {
        private List<Ticket> Tickets { get; set; }

        public TicketRepositoryList()
        {
            Tickets = new List<Ticket>();
        }

        public IEnumerable<Ticket> GetAll()
        {
            return Tickets;
        }

        public Ticket GetById(int id)
        {
            return Tickets[id];
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            Tickets.Add(ticket);
            ticket.Id = Tickets.Count;
            return ticket;
        }

        public bool DelById(int id)
        {
            try
            {
                Tickets.Remove(Tickets[id]);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
