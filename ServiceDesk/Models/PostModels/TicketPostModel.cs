using System;

namespace ServiceDesk.Models.PostModels
{
    public class TicketPostModel
    {
        //public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        //public int DepartmentId { get; set; }
        public DepartmentPostModel Department { get; set; }
    }
}
