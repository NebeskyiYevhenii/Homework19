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
    public class TicketDepartmentController
    {
        private readonly TiketDepartmentService _TiketDepartmentService;
        private readonly IMapper _mapper;

        public TicketDepartmentController()
        {
            _TiketDepartmentService = new TiketDepartmentService();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TicketDepartmentPostModel, TicketDepartmentModel>().ReverseMap();
                cfg.CreateMap<TicketDepartmentViewModel, TicketDepartmentModel>().ReverseMap();

            });

            _mapper = new Mapper(mapperConfig);
        }
        public TicketDepartmentPostModel CreateTicketDepartment(TicketDepartmentPostModel ticketDepartment)
        {
            if (string.IsNullOrWhiteSpace(ticketDepartment.name))
                throw new System.Exception("Invalid name");

            var td = _mapper.Map<TicketDepartmentModel>(ticketDepartment);
            var td1 = _TiketDepartmentService.CreateTicketDepartment(td);
            return _mapper.Map<TicketDepartmentPostModel>(td1); ;
        }
        public TicketDepartmentPostModel GetById(int id)
        {
            var TicketDepartment1 = _TiketDepartmentService.GetById(id);

            return _mapper.Map<TicketDepartmentPostModel>(TicketDepartment1);
        }
        public IEnumerable<TicketDepartmentPostModel> GetAll()
        {
            IEnumerable<TicketDepartmentModel> TicketDepartment = _TiketDepartmentService.GetAll();

            return _mapper.Map<IEnumerable<TicketDepartmentPostModel>>(TicketDepartment);
        }
    }
}
