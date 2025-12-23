using System;
using System.Collections.Generic;
using System.Linq;

namespace FirmsLINQ
{
    class Program
    {
        static void Main()
        {
            // ====== ДАНІ ======
            List<Firm> firms = new List<Firm>
            {
                new Firm
                {
                    Name = "White Food Company",
                    FoundationDate = DateTime.Now.AddYears(-3),
                    BusinessProfile = "Marketing",
                    Director = "John White",
                    EmployeesCount = 150,
                    Address = "London",
                    Employees = new List<Employee>
                    {
                        new Employee("Lionel Messi","Manager","231234","di_messi@mail.com",5000),
                        new Employee("Anna Black","Developer","451234","anna@mail.com",4000)
                    }
                },

                new Firm
                {
                    Name = "Black IT Solutions",
                    FoundationDate = DateTime.Now.AddDays(-123),
                    BusinessProfile = "IT",
                    Director = "Robert Black",
                    EmployeesCount = 250,
                    Address = "London",
                    Employees = new List<Employee>
                    {
                        new Employee("Lionel Richie","Manager","239999","di_rich@mail.com",4500),
                        new Employee("Tom Hardy","Tester","111111","tom@mail.com",3000)
                    }
                },

                new Firm
                {
                    Name = "Green Marketing",
                    FoundationDate = DateTime.Now.AddYears(-1),
                    BusinessProfile = "Marketing",
                    Director = "Alice Brown",
                    EmployeesCount = 90,
                    Address = "Paris",
                    Employees = new List<Employee>
                    {
                        new Employee("Kate Moss","Manager","232222","kate@mail.com",4200)
                    }
                }
            };

            // QS
          

            var allFirms = from f in firms select f;

            var foodFirms = from f in firms
                            where f.Name.Contains("Food")
                            select f;

            var marketingFirms = from f in firms
                                  where f.BusinessProfile == "Marketing"
                                  select f;

            var marketingOrIT = from f in firms
                                where f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT"
                                select f;

            var moreThan100 = from f in firms
                              where f.EmployeesCount > 100
                              select f;

            var between100And300 = from f in firms
                                   where f.EmployeesCount >= 100 && f.EmployeesCount <= 300
                                   select f;

            var londonFirms = from f in firms
                              where f.Address == "London"
                              select f;

            var directorWhite = from f in firms
                                where f.Director.Contains("White")
                                select f;

            var olderThan2Years = from f in firms
                                  where (DateTime.Now - f.FoundationDate).Days > 730
                                  select f;

            var founded123DaysAgo = from f in firms
                                    where (DateTime.Now - f.FoundationDate).Days == 123
                                    select f;

            var blackDirectorWhiteName = from f in firms
                                         where f.Director.Contains("Black") && f.Name.Contains("White")
                                         select f;

            // MS

            var allFirmsM = firms.ToList();

            var foodFirmsM = firms.Where(f => f.Name.Contains("Food"));

            var marketingFirmsM = firms.Where(f => f.BusinessProfile == "Marketing");

            var marketingOrITM = firms.Where(f =>
                f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT");

            var moreThan100M = firms.Where(f => f.EmployeesCount > 100);

            var between100And300M = firms.Where(f =>
                f.EmployeesCount >= 100 && f.EmployeesCount <= 300);

            var londonFirmsM = firms.Where(f => f.Address == "London");

            var directorWhiteM = firms.Where(f => f.Director.Contains("White"));

            var olderThan2YearsM = firms.Where(f =>
                (DateTime.Now - f.FoundationDate).Days > 730);

            var founded123DaysAgoM = firms.Where(f =>
                (DateTime.Now - f.FoundationDate).Days == 123);

            var blackDirectorWhiteNameM = firms.Where(f =>
                f.Director.Contains("Black") && f.Name.Contains("White"));

            // СПІВРОБІТНИКИ

            // Всі співробітники конкретної фірми
            var employeesOfFirm = firms[0].Employees;

            // Зарплата більше заданої
            var highSalary = firms[0].Employees
                .Where(e => e.Salary > 4500);

            // Менеджери усіх фірм
            var managers = firms
                .SelectMany(f => f.Employees)
                .Where(e => e.Position == "Manager");

            // Телефон починається з 23
            var phone23 = firms
                .SelectMany(f => f.Employees)
                .Where(e => e.Phone.StartsWith("23"));

            // Email починається з di
            var emailDi = firms
                .SelectMany(f => f.Employees)
                .Where(e => e.Email.StartsWith("di"));

            // Ім'я Lionel
            var nameLionel = firms
                .SelectMany(f => f.Employees)
                .Where(e => e.FullName.StartsWith("Lionel"));

            Console.WriteLine("Запити виконані успішно.");
        }
    }

    // ===================== КЛАС ФІРМА =====================
    class Firm
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string BusinessProfile { get; set; }
        public string Director { get; set; }
        public int EmployeesCount { get; set; }
        public string Address { get; set; }

        public List<Employee> Employees { get; set; }
    }

    // ===================== КЛАС СПІВРОБІТНИК =====================
    class Employee
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }

        public Employee(string name, string position, string phone, string email, decimal salary)
        {
            FullName = name;
            Position = position;
            Phone = phone;
            Email = email;
            Salary = salary;
        }
    }
}
