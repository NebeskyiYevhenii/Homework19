using ServiceDesk.Data.Interfaces;
using ServiceDesk.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServiceDesk.Data.Repositories
{
    public class TicketDepartmentEFRepository : ITicketDepartmentRepository
    {
        private readonly DepartmentContext _ctx;

        public TicketDepartmentEFRepository()
        {
            _ctx = new DepartmentContext();
        }

        public TicketDepartment CreateTicketDepartment(TicketDepartment ticketDepartment)
        {
            _ctx.TicketDepartments.Add(ticketDepartment);
            _ctx.SaveChanges();
            return ticketDepartment;
        }

        public IEnumerable<TicketDepartment> GetAll()
        {
            return _ctx.TicketDepartments.ToList();
        }

        public TicketDepartment GetById(int id)
        {
            return _ctx.TicketDepartments.FirstOrDefault(x => x.id == id);
        }

        public bool DelById(int id)
        {
            try
            {
                var entity = _ctx.TicketDepartments.FirstOrDefault(x => x.id == id);

                _ctx.TicketDepartments.Remove(entity);

                _ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }


        }
    }
}
