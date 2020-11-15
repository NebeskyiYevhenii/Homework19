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
        public TicketContext() : base(@"Server=.;Initial Catalog = ServiceDesk1; Integrated Security = true")
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(x => x.Tickets)
                .WithRequired(x => x.Department);

            modelBuilder.Entity<Department>()
                .HasMany(x => x.Employees)
                .WithRequired(x => x.Department);

        }
    }
}
