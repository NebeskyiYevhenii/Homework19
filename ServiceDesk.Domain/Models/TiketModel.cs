using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Domain.Models
{
    public class TiketModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public TicketDepartmentModel TicketDepartment { get; set; }
    }
}
