using ServiceDesk.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Data
{
    public class TicketContext : DbContext
    {
        public TicketContext() : base(@"Server=.;Initial Catalog = master; Integrated Security = true")
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketDepartment> TicketDepartments { get; set; }

    }
}
