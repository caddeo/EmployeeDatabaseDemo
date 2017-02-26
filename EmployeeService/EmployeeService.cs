using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in both code and config file together.
    public class EmployeeService : IEmployeeService
    {
        private EmployeeRepository _repository;
        public EmployeeService()
        {
            _repository = new EmployeeRepository();   
        }

        public Employee GetEmployee(Guid id)
        {
            return _repository.GetEmployee(id);
        }

        public List<Employee> GetAllEmployees()
        {
            return _repository.GetAllEmployees();
        }
    }
}
