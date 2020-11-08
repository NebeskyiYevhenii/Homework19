using ServiceDesk.Data.Interfaces;
using ServiceDesk.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Data.Repositories
{
    public class TicketEmployeeEFRepository : ITicketsEmplooyeeRepository
    {
        private readonly EmployeeContext _ctx;

        public TicketEmployeeEFRepository()
        {
            _ctx = new EmployeeContext();
        }

        public TicketEmployee CreateTicketEmployee(TicketEmployee ticketEmployee)
        {
            _ctx.TicketEmployee.Add(ticketEmployee);
            _ctx.SaveChanges();
            return ticketEmployee;
        }

        public IEnumerable<TicketEmployee> GetAll()
        {
            return _ctx.TicketEmployee.ToList();
        }

        public TicketEmployee GetById(int id)
        {
            return _ctx.TicketEmployee.FirstOrDefault(x => x.id == id);
        }

        public bool DelById(int id)
        {
            try
            {
                var entity = _ctx.TicketEmployee.FirstOrDefault(x => x.id == id);

                _ctx.TicketEmployee.Remove(entity);

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
