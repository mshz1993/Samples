using System;

public class Employee
{
    public string Name;
    public Address Address;

    // Shallow Copy
    public Employee ShallowCopy()
    {
        return (Employee)this.MemberwiseClone();
    }

    // Deep Copy
    public Employee DeepCopy()
    {
        Employee clone = (Employee)this.MemberwiseClone();

        clone.Address = new Address
        {
            City = this.Address.City
        };

        return clone;
    }
}

public class Address
{
    public string City;
}

//class Program
//{
//    static void Main(string[] args)
//    {
//        // Employee اصلی
//        Employee employee1 = new Employee
//        {
//            Name = "Ali",
//            Address = new Address
//            {
//                City = "Tehran"
//            }
//        };

//        // Shallow Copy
//        Employee employee2 = employee1.ShallowCopy();

//        // Deep Copy
//        Employee employee3 = employee1.DeepCopy();


//        Console.WriteLine("Before Changes:");
//        Console.WriteLine("----------------");

//        Console.WriteLine($"Employee 1: {employee1.Name} - {employee1.Address.City}");
//        Console.WriteLine($"Employee 2: {employee2.Name} - {employee2.Address.City}");
//        Console.WriteLine($"Employee 3: {employee3.Name} - {employee3.Address.City}");


//        // تغییر Address در employee2
//        employee2.Address.City = "Tabriz";

//        // تغییر Address در employee3
//        employee3.Address.City = "Shiraz";


//        Console.WriteLine();
//        Console.WriteLine("After Changes:");
//        Console.WriteLine("----------------");

//        Console.WriteLine($"Employee 1: {employee1.Name} - {employee1.Address.City}");
//        Console.WriteLine($"Employee 2: {employee2.Name} - {employee2.Address.City}");
//        Console.WriteLine($"Employee 3: {employee3.Name} - {employee3.Address.City}");


//        // بررسی Reference
//        Console.WriteLine();
//        Console.WriteLine("Reference Comparison:");
//        Console.WriteLine("----------------");

//        Console.WriteLine(
//            $"employee1.Address == employee2.Address : " +
//            $"{employee1.Address == employee2.Address}");

//        Console.WriteLine(
//            $"employee1.Address == employee3.Address : " +
//            $"{employee1.Address == employee3.Address}");
//    }
//}