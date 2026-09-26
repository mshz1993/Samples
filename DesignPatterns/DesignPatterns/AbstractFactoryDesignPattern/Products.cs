

namespace AbstractFactoryDesignPattern
{
    using System;

    // =========================
    // Abstract Products
    // =========================

    public interface IPayment
    {
        void Pay();
    }

    public interface IShipping
    {
        void Ship();
    }


    // =========================
    // Iran Products
    // =========================

    public class IranPayment : IPayment
    {
        public void Pay()
        {
            Console.WriteLine("پرداخت ایرانی");
        }
    }

    public class IranShipping : IShipping
    {
        public void Ship()
        {
            Console.WriteLine("ارسال ایرانی");
        }
    }


    // =========================
    // Turkey Products
    // =========================

    public class TurkeyPayment : IPayment
    {
        public void Pay()
        {
            Console.WriteLine("پرداخت ترکیه");
        }
    }

    public class TurkeyShipping : IShipping
    {
        public void Ship()
        {
            Console.WriteLine("ارسال ترکیه");
        }
    }


    // =========================
    // Abstract Factory
    // =========================

    public interface IStoreFactory
    {
        IPayment CreatePayment();
        IShipping CreateShipping();
    }


    // =========================
    // Concrete Factories
    // =========================

    public class IranStoreFactory : IStoreFactory
    {
        public IPayment CreatePayment()
        {
            return new IranPayment();
        }

        public IShipping CreateShipping()
        {
            return new IranShipping();
        }
    }

    public class TurkeyStoreFactory : IStoreFactory
    {
        public IPayment CreatePayment()
        {
            return new TurkeyPayment();
        }

        public IShipping CreateShipping()
        {
            return new TurkeyShipping();
        }
    }


    // =========================
    // Client
    // =========================

    class Program
    {
        static void Main()
        {
            IStoreFactory factory = new IranStoreFactory();

            IPayment payment = factory.CreatePayment();
            IShipping shipping = factory.CreateShipping();

            payment.Pay();
            shipping.Ship();


            Console.WriteLine("----------------");


            factory = new TurkeyStoreFactory();

            payment = factory.CreatePayment();
            shipping = factory.CreateShipping();

            payment.Pay();
            shipping.Ship();
        }
    }
}
