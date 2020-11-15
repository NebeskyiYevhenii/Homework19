using System;

namespace ServiceDesk.Models.ViewModels
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        //public int DepartmentId { get; set; }
        public DepartmentViewModel Department { get; set; }
    }
}
