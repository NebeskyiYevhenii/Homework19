using AutoMapper;
using ServiceDesk.Data.Models;
using ServiceDesk.Data.Repositories;
using ServiceDesk.Domain.Models;
using System.Collections.Generic;

namespace ServiceDesk.Domain
{
    public class DepartmentService
    {
        private readonly TicketDepartmentEFRepository _ticketDepartmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService()
        {
            _ticketDepartmentRepository = new TicketDepartmentEFRepository();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DepartmentModel, Department>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public DepartmentModel CreateTicketDepartment(DepartmentModel _department)
        {
            var department = _mapper.Map<Department>(_department);
            department = _ticketDepartmentRepository.CreateTicketDepartment(department);
            _department.id = department.id;
            return _department;
        }

        public DepartmentModel GetById(int id)
        {
            var _ticketDepartment = _ticketDepartmentRepository.GetById(id);

            return _mapper.Map<DepartmentModel>(_ticketDepartment);
        }

        public IEnumerable<DepartmentModel> GetAll()
        {
            IEnumerable<Department> department = _ticketDepartmentRepository.GetAll();
            return _mapper.Map<IEnumerable<DepartmentModel>>(department);
        }

    }
}
