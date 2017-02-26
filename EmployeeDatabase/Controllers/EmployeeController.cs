using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using EmployeeDatabase.EmployeeService;
using EmployeeDatabase.Repositories;

namespace EmployeeDatabase.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeRepository _repository;
        public EmployeeController()
        {
            _repository = new EmployeeRepository();
        }
        // GET: Employee
        [Route("api/employees/")]
        public IEnumerable<Employee> Get()
        {
            var employees = _repository.GetAllEmployees();
            return employees;
        }

        // GET: Employee
        [Route("api/employees/{id}")]
        public IHttpActionResult Get(Guid id)
        {
            var employee = _repository.GetEmployee(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
    }
}