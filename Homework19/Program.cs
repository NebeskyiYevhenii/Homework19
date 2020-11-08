using ServiceDesk.Controller;
using ServiceDesk.Models.PostModels;

namespace Homework19
{
    public class Program
    {
        static void Main(string[] args)
        {
            var controller = new TicketController();
            var controllerDepartment = new TicketDepartmentController();
            var controllerEmployee = new TicketEmployeeController();

            var ticket2 = new TicketPostModel
            {
                Title = "Title3",
                Description = "Ticket Description2",
                Date = System.DateTime.Now,
                DepartmentId = 6,
            };

            var ticketDepartment = new TicketDepartmentPostModel
            {
                name = "Department1"
            };

            var ticketEmployee = new TicketEmployeePostModel
            {
                name = "Yasha",
                DepartmentId = 6,
            };

            //var CreateTicketEmployee = controllerEmployee.CreateTicketEmployee(ticketEmployee);
            //var GetByIdEmployee = controllerEmployee.GetById(1);
            var GetAllTicketEmployee = controllerEmployee.GetAll();
            //var CreateTicketDepartment = controllerDepartment.CreateTicketDepartment(ticketDepartment);
            var GetAllTicketDepartment = controllerDepartment.GetAll();
            //var CreateTicket = controller.CreateTicket(ticket2);
            //var GetById = controller.GetById(3);
            var GetAll = controller.GetAll();
            var DelById = controller.DelById(3);

        }
    }
}
