using AutoMapper;
using ServiceDesk.Data.Interfaces;
using ServiceDesk.Data.Models;
using ServiceDesk.Data.Repositories;
using ServiceDesk.Domain.Models;
using System.Collections.Generic;

namespace ServiceDesk.Domain
{
    public class ServiceDeskService
    {
        private readonly ITicketsRepository _ticketRepository;
        private readonly IMapper _mapper;
        public ServiceDeskService()
        {
            _ticketRepository = new TicketRepository();
            _ticketRepository = new TicketRepositoryDB();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                var map = cfg.CreateMap<TiketModel, Ticket>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }
        public TiketModel CreateTicket(TiketModel ticket)
        {
            var tic = _mapper.Map<Ticket>(ticket);
            var tic1 = _ticketRepository.CreateTicket(tic);
            return _mapper.Map<TiketModel>(tic1);
        }
        public TiketModel GetById(int id)
        {
            var Ticket1 = _ticketRepository.GetById(id);

            return _mapper.Map<TiketModel>(Ticket1);
        }

        public IEnumerable<TiketModel> GetAll()
        {
            IEnumerable<Ticket> models = _ticketRepository.GetAll();
            return _mapper.Map<IEnumerable<TiketModel>>(models);
        }

    }
}
