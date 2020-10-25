using ServiceDesk.Controller;
using ServiceDesk.Models.PostModels;

namespace Homework19
{
    public class Program
    {
        static void Main(string[] args)
        {
            var controller = new TicketController();

            var ticket = new CreateTicketPostModel
            {
                Title = "Title",
                Type = "Ticket type",
                Description = "Ticket Description"
            };

            var ticket2 = new CreateTicketPostModel
            {
                Title = "Title2",
                Type = "Ticket type2",
                Description = "Ticket Description2"
            };

            controller.CreateTicket(ticket);
            controller.CreateTicket(ticket2);
            var teket0 = controller.GetTicket(1);

        }
    }
}
