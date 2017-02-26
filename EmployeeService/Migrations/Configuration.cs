using System.Collections.Generic;

namespace EmployeeService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EmployeeContext context)
        {
            if (context.Employees.Count() < 10)
            {

                var names = new string[] { "Patrick", "Jens", "Morten", "Peter", "Frank", "Anna", "Jane", "Julie" };

                var random = new Random((int)DateTime.Now.Ticks / 2);

                for (var i = 0; i < 10; i++)
                {
                    var birthDay = random.Next(1, 28);
                    var birthMonth = random.Next(1, 12);
                    var birthYear = random.Next(1946, 2001);
                    var birthdate = new DateTime(birthYear, birthMonth, birthDay);

                    var name = names[random.Next(names.Length - 1)];
                    
                    context.Employees.AddOrUpdate(new Employee(name, birthdate));
                }
            }

            context.SaveChanges();
        }
    }
}
