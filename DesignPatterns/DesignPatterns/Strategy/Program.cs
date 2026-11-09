
using System;

namespace StrategyPatternExample
{
    // 1. قرارداد مشترک الگوریتم‌های ارسال
    public interface IShippingStrategy
    {
        decimal CalculateCost(decimal orderAmount);
    }

    // 2. ارسال معمولی
    public class StandardShipping : IShippingStrategy
    {
        public decimal CalculateCost(decimal orderAmount)
        {
            return 50;
        }
    }

    // 3. ارسال سریع
    public class ExpressShipping : IShippingStrategy
    {
        public decimal CalculateCost(decimal orderAmount)
        {
            return 100;
        }
    }

    // 4. ارسال رایگان برای سفارش‌های واجد شرایط
    public class FreeShipping : IShippingStrategy
    {
        public decimal CalculateCost(decimal orderAmount)
        {
            return 0;
        }
    }

    // 5. کلاس اصلی سفارش
    public class Order
    {
        private IShippingStrategy _shippingStrategy;

        public Order(IShippingStrategy shippingStrategy)
        {
            _shippingStrategy = shippingStrategy;
        }

        // امکان تغییر الگوریتم در زمان اجرا
        public void SetShippingStrategy(
            IShippingStrategy shippingStrategy)
        {
            _shippingStrategy = shippingStrategy;
        }

        public decimal CalculateShipping(decimal orderAmount)
        {
            return _shippingStrategy.CalculateCost(orderAmount);
        }
    }

    // 6. اجرای برنامه
    internal class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order(new StandardShipping());

            Console.WriteLine(
                $"Standard: {order.CalculateShipping(500)}");

            order.SetShippingStrategy(new ExpressShipping());

            Console.WriteLine(
                $"Express: {order.CalculateShipping(500)}");

            order.SetShippingStrategy(new FreeShipping());

            Console.WriteLine(
                $"Free: {order.CalculateShipping(500)}");

            Console.ReadKey();
        }
    }
}
