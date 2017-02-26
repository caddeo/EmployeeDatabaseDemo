using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeDatabase.EmployeeService;

namespace EmployeeDatabase.Repositories
{
    public class EmployeeRepository
    {
        private EmployeeServiceClient _service;

        public EmployeeRepository()
        {
            _service = new EmployeeServiceClient();
        }

        public Employee GetEmployee(Guid id)
        {
            return _service.GetEmployee(id);
        }

        public List<Employee> GetAllEmployees()
        {
            return _service
                .GetAllEmployees()
                .ToList();
        }
    }
}