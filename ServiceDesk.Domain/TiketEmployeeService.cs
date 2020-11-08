using AutoMapper;
using ServiceDesk.Data.Models;
using ServiceDesk.Data.Repositories;
using ServiceDesk.Domain.Models;
using System.Collections.Generic;

namespace ServiceDesk.Domain
{
    public class TiketEmployeeService
    {
        private readonly TicketEmployeeEFRepository _ticketEmployeeRepository;
        private readonly IMapper _mapper;
        public TiketEmployeeService()
        {
            _ticketEmployeeRepository = new TicketEmployeeEFRepository();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TicketEmployeeModel, TicketEmployee>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }
        public TicketEmployeeModel CreateTicketEmployee(TicketEmployeeModel ticket)
        {
            var tic = _mapper.Map<TicketEmployee>(ticket);
            tic = _ticketEmployeeRepository.CreateTicketEmployee(tic);
            ticket.id = tic.id;
            return ticket;
        }
        public TicketEmployeeModel GetById(int id)
        {
            var TicketEmployee1 = _ticketEmployeeRepository.GetById(id);

            return _mapper.Map<TicketEmployeeModel>(TicketEmployee1);
        }
        public IEnumerable<TicketEmployeeModel> GetAll()
        {
            IEnumerable<TicketEmployee> models = _ticketEmployeeRepository.GetAll();
            return _mapper.Map<IEnumerable<TicketEmployeeModel>>(models);
        }

    }
}
