using ServiceDesk.Data.Models;
using System.Data.Entity;

namespace ServiceDesk.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base(@"Server=.;Initial Catalog = ServiceDesk1; Integrated Security = true")
        {
        }
        public DbSet<Employee> TicketEmployee { get; set; }
    }
}
