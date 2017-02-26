using System;
using System.Runtime.Serialization;

namespace EmployeeService
{
    [DataContract]
    public class Employee
    {

        [DataMember]
        public Guid Id { get; protected set; }

        [DataMember]
        public string Name { get; protected set; }

        [DataMember]
        public DateTime Birthdate { get; protected set; }

        [DataMember]
        public int Age { get; protected set; }

        public Employee(string name, DateTime birthdate)
        {
            this.Id = Guid.NewGuid();
            SetName(name);
            SetBirthdate(birthdate);
            SetAge();
        }

        public Employee() : this(string.Empty, DateTime.MinValue)
        {
        }

        private void SetName(string name)
        {
            this.Name = name;
        }

        private void SetBirthdate(DateTime birthdate)
        {
            this.Birthdate = birthdate;
        }

        private void SetAge()
        {
            this.Age = DateTime.Now.Year - Birthdate.Year;
        }
    }
}