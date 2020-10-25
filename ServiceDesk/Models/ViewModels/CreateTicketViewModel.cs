using System;

namespace ServiceDesk.Models.ViewModels
{
    public class CreateTicketViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
