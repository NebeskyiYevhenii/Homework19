using ServiceDesk.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Data.Interfaces
{
    public interface ITicketDepartmentRepository
    {
        IEnumerable<Department> GetAll();

        Department CreateTicketDepartment(Department model);

        Department GetById(int id);
    }
}
