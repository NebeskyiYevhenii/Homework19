using AutoMapper;
using ServiceDesk.Data.Models;
using ServiceDesk.Domain;
using ServiceDesk.Domain.Models;
using ServiceDesk.Models.PostModels;
using System;

namespace ServiceDesk.Controller
{
    public class TicketController
    {
        private readonly ServiceDeskService _serviceDeskService;
        private readonly IMapper _mapper;
        private int idTickets = 0;

        public TicketController()
        {
            _serviceDeskService = new ServiceDeskService();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                var map = cfg.CreateMap<CreateTicketPostModel, Ticket>();
            });

            var mapper = new Mapper(mapperConfig);
        }

        public void CreateTicket(CreateTicketPostModel ticket)
        {
            if (string.IsNullOrWhiteSpace(ticket.Title))
                throw new System.Exception("Invalid FullName");
            if (string.IsNullOrWhiteSpace(ticket.Description))
                throw new System.Exception("Invalid Description");

            //var tic = _mapper.Map<Ticket>(ticket);

            var tiketModel = new TiketModel
            {
                Id = idTickets,
                Title = ticket.Title,
                Type = ticket.Type,
                Date = DateTime.UtcNow,
                Description = ticket.Description
            };

            _serviceDeskService.CreateTicket(tiketModel);
            idTickets++;
        }
        public CreateTicketPostModel GetTicket(int id)
        {
            var Ticket1 = _serviceDeskService.GetTicket(id);

            var tiketModel = new CreateTicketPostModel
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
