using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ServiceDesk.Domain;
using ServiceDesk.Domain.Models;
using ServiceDesk.Models.PostModels;
using ServiceDesk.Models.ViewModels;

namespace ServiceDesk.Controller
{
    public class DepartmentController
    {
        private readonly DepartmentService _TiketDepartmentService;
        private readonly IMapper _mapper;

        public DepartmentController()
        {
            _TiketDepartmentService = new DepartmentService();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DepartmentPostModel, DepartmentModel>().ReverseMap();
                cfg.CreateMap<DepartmentViewModel, DepartmentModel>().ReverseMap();

            });

            _mapper = new Mapper(mapperConfig);
        }
        public DepartmentPostModel CreateTicketDepartment(DepartmentPostModel ticketDepartment)
        {
            if (string.IsNullOrWhiteSpace(ticketDepartment.name))
                throw new System.Exception("Invalid name");

            var td = _mapper.Map<DepartmentModel>(ticketDepartment);
            var td1 = _TiketDepartmentService.CreateTicketDepartment(td);
            return _mapper.Map<DepartmentPostModel>(td1); ;
        }
        public DepartmentPostModel GetById(int id)
        {
            var TicketDepartment1 = _TiketDepartmentService.GetById(id);

            return _mapper.Map<DepartmentPostModel>(TicketDepartment1);
        }
        public IEnumerable<DepartmentPostModel> GetAll()
        {
            IEnumerable<DepartmentModel> TicketDepartment = _TiketDepartmentService.GetAll();

            return _mapper.Map<IEnumerable<DepartmentPostModel>>(TicketDepartment);
        }
    }
}
