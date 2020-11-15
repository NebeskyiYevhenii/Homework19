using ServiceDesk.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Data.Interfaces
{
    public interface ITicketsEmplooyeeRepository
    {
        IEnumerable<Employee> GetAll();

        Employee CreateEmployeeEmployee(Employee model);

        Employee GetById(int id);
    }
}
