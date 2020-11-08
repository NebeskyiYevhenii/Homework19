using ServiceDesk.Data.Models;
using System.Data.Entity;

namespace ServiceDesk.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base(@"Server=.;Initial Catalog = master; Integrated Security = true")
        {
        }
        public DbSet<TicketEmployee> TicketEmployee { get; set; }
    }
}
