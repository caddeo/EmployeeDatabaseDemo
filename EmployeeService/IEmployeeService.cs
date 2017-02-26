using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeService" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        Employee GetEmployee(Guid id);

        [OperationContract]
        List<Employee> GetAllEmployees();
    }
}
