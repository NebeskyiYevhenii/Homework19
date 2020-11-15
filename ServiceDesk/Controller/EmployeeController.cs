using AutoMapper;
using ServiceDesk.Domain;
using ServiceDesk.Domain.Models;
using ServiceDesk.Models.PostModels;
using ServiceDesk.Models.ViewModels;
using System.Collections.Generic;

namespace ServiceDesk.Controller
{
    public class EmployeeController
    {
        private readonly EmployeeService _TiketEmployeeService;
        private readonly IMapper _mapper;

        public EmployeeController()
        {
            _TiketEmployeeService = new EmployeeService();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeePostModel, EmployeeModel>().ReverseMap();
                cfg.CreateMap<EmployeeViewModel, EmployeeModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }
        public EmployeePostModel CreateTicketEmployee(EmployeePostModel ticketEmployee)
        {
            if (string.IsNullOrWhiteSpace(ticketEmployee.name))
                throw new System.Exception("Invalid name");

            var td = _mapper.Map<EmployeeModel>(ticketEmployee);
            var td1 = _TiketEmployeeService.CreateEmployeeEmployee(td);
            return _mapper.Map<EmployeePostModel>(td1); ;
        }
        public EmployeePostModel GetById(int id)
        {
            var TicketEmployee1 = _TiketEmployeeService.GetById(id);

            return _mapper.Map<EmployeePostModel>(TicketEmployee1);
        }
        public IEnumerable<EmployeePostModel> GetAll()
        {
            IEnumerable<EmployeeModel> TicketEmployee = _TiketEmployeeService.GetAll();

            return _mapper.Map<IEnumerable<EmployeePostModel>>(TicketEmployee);
        }
    }
}
