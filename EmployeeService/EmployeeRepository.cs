using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService
{
    public class EmployeeRepository
    {
        private readonly EmployeeContext context;

        private List<Employee> _employees => context.Employees.ToList();

        public EmployeeRepository()
        {
            context = new EmployeeContext();


        }

        public Employee GetEmployee(Guid id)
        {
            return _employees.FirstOrDefault(x => x.Id == id);
        }

        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }
    }

    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("EmployeeContext") { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
