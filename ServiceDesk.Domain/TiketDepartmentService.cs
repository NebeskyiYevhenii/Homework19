using AutoMapper;
using ServiceDesk.Data.Models;
using ServiceDesk.Data.Repositories;
using ServiceDesk.Domain.Models;
using System.Collections.Generic;

namespace ServiceDesk.Domain
{
    public class TiketDepartmentService
    {
        private readonly TicketDepartmentEFRepository _ticketDepartmentRepository;
        private readonly IMapper _mapper;
        public TiketDepartmentService()
        {
            _ticketDepartmentRepository = new TicketDepartmentEFRepository();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TicketDepartmentModel, TicketDepartment>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }
        public TicketDepartmentModel CreateTicketDepartment(TicketDepartmentModel ticket)
        {
            var tic = _mapper.Map<TicketDepartment>(ticket);
            tic = _ticketDepartmentRepository.CreateTicketDepartment(tic);
            ticket.id = tic.id;
            return ticket;
        }
        public TicketDepartmentModel GetById(int id)
        {
            var TicketDepartment1 = _ticketDepartmentRepository.GetById(id);

            return _mapper.Map<TicketDepartmentModel>(TicketDepartment1);
        }
        public IEnumerable<TicketDepartmentModel> GetAll()
        {
            IEnumerable<TicketDepartment> models = _ticketDepartmentRepository.GetAll();
            return _mapper.Map<IEnumerable<TicketDepartmentModel>>(models);
        }

    }
}
