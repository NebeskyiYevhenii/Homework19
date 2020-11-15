using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Models.PostModels
{
    public class EmployeePostModel
    {
        //public int id { get; set; }
        public string name { get; set; }
        //public int DepartmentId { get; set; }
        public DepartmentPostModel Department { get; set; }
    }
}
