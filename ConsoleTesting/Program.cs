using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTesting.ServiceReference1;

namespace ConsoleTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }

        public void Run()
        {
            var service = new EmployeeServiceClient();

            var employees = service.GetAllEmployees();
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Id}, {employee.Name}");
            }

            Console.ReadKey(true);
        }
    }
}
