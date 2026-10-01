using System;
using System.Collections.Generic;

namespace Composite
{
    public interface IEmployee
    {
        void ShowInfo(int level = 0);
    }

    // Leaf
    public class Developer : IEmployee
    {
        public string Name { get; set; }

        public Developer(string name)
        {
            Name = name;
        }

        public void ShowInfo(int level = 0)
        {
            Console.WriteLine($"{new string(' ', level * 4)}├── {Name} - Developer");
        }
    }

    // Composite
    public class Team : IEmployee
    {
        public string Name { get; set; }

        private readonly List<IEmployee> employees = new();

        public Team(string name)
        {
            Name = name;
        }

        public void Add(IEmployee employee)
        {
            employees.Add(employee);
        }

        public void ShowInfo(int level = 0)
        {
            Console.WriteLine($"{new string(' ', level * 4)}├── {Name} - Team");

            foreach (var employee in employees)
            {
                employee.ShowInfo(level + 1);
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            // Developers - Leaf
            var dev1 = new Developer("Ali");
            var dev2 = new Developer("Reza");
            var dev3 = new Developer("Amir");

            // Teams - Composite
            var backend = new Team("Backend");
            var frontend = new Team("Frontend");

            backend.Add(dev1);
            backend.Add(dev2);

            frontend.Add(dev3);

            // Company - Composite
            var company = new Team("Company");

            company.Add(backend);
            company.Add(frontend);

            // نمایش ساختار
            company.ShowInfo();
        }
    }
}