
using System;
using System.Collections.Generic;

namespace ObserverPatternExample
{
    // 1. قرارداد مشترک ناظرها
    public interface IObserver
    {
        void Update(string message);
    }

    // 2. ناظر اول
    public class Customer : IObserver
    {
        public string Name { get; }

        public Customer(string name)
        {
            Name = name;
        }

        public void Update(string message)
        {
            Console.WriteLine($"{Name} received: {message}");
        }
    }

    // 3. موضوعی که تغییرات را اعلام می‌کند
    public class Product
    {
        private readonly List<IObserver> _observers =
            new List<IObserver>();

        public string Name { get; }

        private decimal _price;

        public Product(string name, decimal price)
        {
            Name = name;
            _price = price;
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void ChangePrice(decimal newPrice)
        {
            _price = newPrice;

            NotifyObservers(
                $"Price of {Name} changed to {_price}");
        }

        private void NotifyObservers(string message)
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update(message);
            }
        }
    }

    // 4. اجرای برنامه
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("Laptop", 1000);

            Customer ali = new Customer("Ali");
            Customer sara = new Customer("Sara");

            // ثبت مشترک‌ها
            product.Subscribe(ali);
            product.Subscribe(sara);

            // تغییر قیمت و اطلاع‌رسانی خودکار
            product.ChangePrice(900);

            // لغو اشتراک علی
            product.Unsubscribe(ali);

            product.ChangePrice(800);

            Console.ReadKey();
        }
    }
}
