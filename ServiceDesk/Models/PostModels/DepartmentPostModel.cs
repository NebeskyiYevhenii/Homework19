using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Models.PostModels
{
    public class DepartmentPostModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<TicketPostModel> Tickets { get; set; }
        public ICollection<EmployeePostModel> Employees { get; set; }
    }
}
