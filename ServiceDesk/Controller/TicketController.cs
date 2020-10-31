using AutoMapper;
using ServiceDesk.Domain;
using ServiceDesk.Domain.Models;
using ServiceDesk.Models.PostModels;
using System.Collections.Generic;

namespace ServiceDesk.Controller
{
    public class TicketController
    {
        private readonly ServiceDeskService _serviceDeskService;
        private readonly IMapper _mapper;
        //private int idTickets = 0;

        public TicketController()
        {
            _serviceDeskService = new ServiceDeskService();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                var map = cfg.CreateMap<TicketPostModel, TiketModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public TicketPostModel CreateTicket(TicketPostModel ticket)
        {
            if (string.IsNullOrWhiteSpace(ticket.Title))
                throw new System.Exception("Invalid Title");
            if (string.IsNullOrWhiteSpace(ticket.Description))
                throw new System.Exception("Invalid Description");

            var tic = _mapper.Map<TiketModel>(ticket);
            var tic1 = _serviceDeskService.CreateTicket(tic);
            return _mapper.Map<TicketPostModel>(tic1); ;
        }
        public TicketPostModel GetById(int id)
        {
            var Ticket1 = _serviceDeskService.GetById(id);

            return _mapper.Map<TicketPostModel>(Ticket1);
        }
        public IEnumerable<TicketPostModel> GetAll()
        {
            IEnumerable<TiketModel> models = _serviceDeskService.GetAll();

            return _mapper.Map<IEnumerable<TicketPostModel>>(models);
        }
    }
}
