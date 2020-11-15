using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Data.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        //public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
