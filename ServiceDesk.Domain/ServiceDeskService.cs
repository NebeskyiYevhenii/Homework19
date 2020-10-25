using ServiceDesk.Data.Models;
using ServiceDesk.Data.Repositories;
using ServiceDesk.Domain.Models;

namespace ServiceDesk.Domain
{
    public class ServiceDeskService
    {
        private readonly TicketRepository _ticketRepository;
        public ServiceDeskService()
        {
            _ticketRepository = new TicketRepository();
        }
        public void CreateTicket(TiketModel ticket)
        {
            // Проверка ести ли свободное  окно, 
            // чтобы записать на мойку эту машину

            var tiketModel = new Ticket
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Type = ticket.Type,
                Date = ticket.Date,
                Description = ticket.Description
            };

            _ticketRepository.Create(tiketModel);

        }
        public TiketModel GetTicket(int id)
        {

            var Ticket1 = _ticketRepository.Get(id);

            var tiketModel = new TiketModel
            {
                Id = Ticket1.Id,
                Title = Ticket1.Title,
                Type = Ticket1.Type,
                Date = Ticket1.Date,
                Description = Ticket1.Description
            };

            return tiketModel;
        }

    }
}
