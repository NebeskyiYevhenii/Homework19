using AutoMapper;
using ServiceDesk.Data.Models;
using ServiceDesk.Data.Repositories;
using ServiceDesk.Domain.Models;
using System.Collections.Generic;

namespace ServiceDesk.Domain
{
    public class EmployeeService
    {
        private readonly TicketEmployeeEFRepository _ticketEmployeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService()
        {
            _ticketEmployeeRepository = new TicketEmployeeEFRepository();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeModel, Employee>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public EmployeeModel CreateEmployeeEmployee(EmployeeModel _employee)
        {
            var employee = _mapper.Map<Employee>(_employee);
            employee = _ticketEmployeeRepository.CreateEmployeeEmployee(employee);
            _employee.id = employee.id;
            return _employee;
        }

        public EmployeeModel GetById(int id)
        {
            var _ticketEmployee = _ticketEmployeeRepository.GetById(id);

            return _mapper.Map<EmployeeModel>(_ticketEmployee);
        }

        public IEnumerable<EmployeeModel> GetAll()
        {
            IEnumerable<Employee> employee = _ticketEmployeeRepository.GetAll();
            return _mapper.Map<IEnumerable<EmployeeModel>>(employee);
        }

    }
}
