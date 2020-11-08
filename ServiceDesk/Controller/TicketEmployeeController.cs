using AutoMapper;
using ServiceDesk.Domain;
using ServiceDesk.Domain.Models;
using ServiceDesk.Models.PostModels;
using ServiceDesk.Models.ViewModels;
using System.Collections.Generic;

namespace ServiceDesk.Controller
{
    public class TicketEmployeeController
    {
        private readonly TiketEmployeeService _TiketEmployeeService;
        private readonly IMapper _mapper;

        public TicketEmployeeController()
        {
            _TiketEmployeeService = new TiketEmployeeService();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TicketEmployeePostModel, TicketEmployeeModel>().ReverseMap();
                cfg.CreateMap<TicketEmployeeViewModel, TicketEmployeeModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }
        public TicketEmployeePostModel CreateTicketEmployee(TicketEmployeePostModel ticketEmployee)
        {
            if (string.IsNullOrWhiteSpace(ticketEmployee.name))
                throw new System.Exception("Invalid name");

            var td = _mapper.Map<TicketEmployeeModel>(ticketEmployee);
            var td1 = _TiketEmployeeService.CreateTicketEmployee(td);
            return _mapper.Map<TicketEmployeePostModel>(td1); ;
        }
        public TicketEmployeePostModel GetById(int id)
        {
            var TicketEmployee1 = _TiketEmployeeService.GetById(id);

            return _mapper.Map<TicketEmployeePostModel>(TicketEmployee1);
        }
        public IEnumerable<TicketEmployeePostModel> GetAll()
        {
            IEnumerable<TicketEmployeeModel> TicketEmployee = _TiketEmployeeService.GetAll();

            return _mapper.Map<IEnumerable<TicketEmployeePostModel>>(TicketEmployee);
        }
    }
}
