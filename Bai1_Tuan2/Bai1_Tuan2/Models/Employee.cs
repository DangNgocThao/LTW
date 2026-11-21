using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai1_Tuan2.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }
        public Employee()
        {
            Id = "101";
            Name = "Mr.Trung";
            Address = "140 Lê Trọng Tấn";
            Salary = 2000;
        }
        public Employee(string Id, string Name, string Address, double Salary)
        {
            this.Id = Id;
            this.Name = Name;
            this.Address = Address;
            this.Salary = Salary;
        }
    }
}