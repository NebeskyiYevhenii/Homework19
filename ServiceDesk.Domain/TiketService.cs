using AutoMapper;
using ServiceDesk.Data.Interfaces;
using ServiceDesk.Data.Models;
using ServiceDesk.Data.Repositories;
using ServiceDesk.Domain.Models;
using System.Collections.Generic;

namespace ServiceDesk.Domain
{
    public class TiketService
    {
        private readonly ITicketsRepository _ticketRepository;
        private readonly IMapper _mapper;

        public TiketService()
        {
            //_ticketRepository = new TicketRepositoryList();
            //_ticketRepository = new TicketRepository();
            _ticketRepository = new TicketEFRepository();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TiketModel, Ticket>().ReverseMap();
                cfg.CreateMap<DepartmentModel, Department>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public TiketModel CreateTicket(TiketModel ticket)
        {
            var tic = _mapper.Map<Ticket>(ticket);
            _ticketRepository.CreateTicket(tic);
            return ticket;
        }

        public TiketModel GetById(int id)
        {
            var Ticket1 = _ticketRepository.GetById(id);

            return _mapper.Map<TiketModel>(Ticket1);
        }

        public bool DelById(int id)
        {
            return _ticketRepository.DelById(id);
        }

        public IEnumerable<TiketModel> GetAll()
        {
            IEnumerable<Ticket> models = _ticketRepository.GetAll();
            return _mapper.Map<IEnumerable<TiketModel>>(models);
        }

    }
}
