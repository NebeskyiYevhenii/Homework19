using ServiceDesk.Data.Interfaces;
using ServiceDesk.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Data.Repositories
{
    public class TicketEFRepository : ITicketsRepository
    {
        private readonly TicketContext _ctx;

        public TicketEFRepository()
        {
            _ctx = new TicketContext();
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            _ctx.Tickets.Add(ticket);
            _ctx.SaveChanges();
            return ticket;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _ctx.Tickets.ToList();
        }

        public Ticket GetById(int id)
        {
            return _ctx.Tickets.FirstOrDefault(x => x.Id == id);
        }

        public bool DelById(int id)
        {
            try
            {
                var entity = _ctx.Tickets.FirstOrDefault(x => x.Id == id);

                _ctx.Tickets.Remove(entity);

                _ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }


        }
    }
}
