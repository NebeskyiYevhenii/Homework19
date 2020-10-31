using System;

namespace ServiceDesk.Models.PostModels
{
    public class TicketPostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

    }
}
