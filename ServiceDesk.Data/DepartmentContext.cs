using ServiceDesk.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Data
{
    class DepartmentContext : DbContext
    {
        public DepartmentContext() : base(@"Server=.;Initial Catalog = ServiceDesk1; Integrated Security = true")
        {
        }
        public DbSet<Department> TicketDepartments { get; set; }
    }
}
