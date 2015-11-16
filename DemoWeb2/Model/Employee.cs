using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWeb2.Model
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string F_Name { get; set; }
        public string L_Name { get; set; }
        public string City { get; set; }
        public string EmailId { get; set; }
        public DateTime  EmpJoining { get; set; }


    }
}