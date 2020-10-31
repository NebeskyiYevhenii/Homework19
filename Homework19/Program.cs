using ServiceDesk.Controller;
using ServiceDesk.Models.PostModels;

namespace Homework19
{
    public class Program
    {
        static void Main(string[] args)
        {
            var controller = new TicketController();

            var ticket2 = new TicketPostModel
            {
                Title = "Title2",
                Type = "Ticket type2",
                Description = "Ticket Description2",
                Date = System.DateTime.Now
            };

            var CreateTicket = controller.CreateTicket(ticket2);
            var GetById = controller.GetById(3);
            var GetAll = controller.GetAll();

        }
    }
}
