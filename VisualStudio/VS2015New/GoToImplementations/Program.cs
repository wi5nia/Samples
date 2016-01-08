using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoToImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepository er = new EmployeeRepository();

            Employee emp = er.GetById(2);
        }
    }

    class EmployeeRepository : IEmployeeRepository
    {
        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }
    }

    interface IEmployeeRepository
    {
        Employee GetById(int id);
    }

    class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
    }
}
