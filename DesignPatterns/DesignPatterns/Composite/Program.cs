using System;
using System.Collections.Generic;

// A common interface for all employees
interface IEmployee
{
    void ShowEmployeeDetails();
}

class Developer : IEmployee
{
    private long empId;
    private string name;
    private string position;

    public Developer(long empId, string name, string position)
    {
        this.empId = empId;
        this.name = name;
        this.position = position;
    }

    public void ShowEmployeeDetails()
    {
        Console.WriteLine($"{empId} {name} {position}");
    }
}

class Manager : IEmployee
{
    private long empId;
    private string name;
    private string position;

    public Manager(long empId, string name, string position)
    {
        this.empId = empId;
        this.name = name;
        this.position = position;
    }

    public void ShowEmployeeDetails()
    {
        Console.WriteLine($"{empId} {name} {position}");
    }
}

// Class used to get Employee List 
// and do the operations like 
// add or remove Employee 
class CompanyDirectory : IEmployee
{
    private List<IEmployee> employeeList = new List<IEmployee>();

    public void ShowEmployeeDetails()
    {
        foreach (IEmployee emp in employeeList)
        {
            emp.ShowEmployeeDetails();
        }
    }

    public void AddEmployee(IEmployee emp)
    {
        employeeList.Add(emp);
    }

    public void RemoveEmployee(IEmployee emp)
    {
        employeeList.Remove(emp);
    }
}

// Driver class 
class Company
{
    public static void Main(string[] args)
    {
        Developer dev1 = new Developer(100, "Lokesh Sharma", "Pro Developer");
        Developer dev2 = new Developer(101, "Vinay Sharma", "Developer");

        CompanyDirectory engDirectory = new CompanyDirectory();
        engDirectory.AddEmployee(dev1);
        engDirectory.AddEmployee(dev2);

        Manager man1 = new Manager(200, "Kushagra Garg", "SEO Manager");
        Manager man2 = new Manager(201, "Vikram Sharma", "Kushagra's Manager");

        CompanyDirectory accDirectory = new CompanyDirectory();
        accDirectory.AddEmployee(man1);
        accDirectory.AddEmployee(man2);

        CompanyDirectory directory = new CompanyDirectory();
        directory.AddEmployee(engDirectory);
        directory.AddEmployee(accDirectory);
        directory.ShowEmployeeDetails();
    }
}
