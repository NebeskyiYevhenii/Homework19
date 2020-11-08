using System;

namespace ServiceDesk.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public int DepartmentId { get; set; }
        public TicketDepartment TicketDepartment { get; set; }
    }
}
