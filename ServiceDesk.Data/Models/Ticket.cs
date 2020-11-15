using System;

namespace ServiceDesk.Data.Models
{
    public class Ticket
    {
        public int id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        //public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
