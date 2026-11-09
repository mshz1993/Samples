
using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorPatternExample
{
    // 1. مجموعه‌ای از کارمندان
    public class EmployeeCollection : IEnumerable<string>
    {
        private readonly List<string> _employees = new List<string>();

        public void Add(string employee)
        {
            _employees.Add(employee);
        }

        // فراهم کردن امکان پیمایش مجموعه
        public IEnumerator<string> GetEnumerator()
        {
            return _employees.GetEnumerator();
        }

        // پیاده‌سازی قرارداد غیر Generic
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeCollection employees = new EmployeeCollection();

            employees.Add("Ali");
            employees.Add("Sara");
            employees.Add("Reza");

            // پیمایش بدون دسترسی مستقیم به لیست داخلی
            foreach (string employee in employees)
            {
                Console.WriteLine(employee);
            }

            Console.ReadKey();
        }
    }
}
