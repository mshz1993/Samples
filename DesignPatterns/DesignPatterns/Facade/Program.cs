using System;

namespace Facade
{
    // ============================================
    // Subsystem 1
    // ============================================
    public class Inventory
    {
        public bool CheckStock()
        {
            Console.WriteLine("Checking inventory...");

            return true;
        }
    }


    // ============================================
    // Subsystem 2
    // ============================================
    public class Payment
    {
        public bool Pay()
        {
            Console.WriteLine("Processing payment...");

            return true;
        }
    }


    // ============================================
    // Subsystem 3
    // ============================================
    public class Shipping
    {
        public void Ship()
        {
            Console.WriteLine("Shipping order...");
        }
    }


    // ============================================
    // Facade
    // ============================================
    // Facade پیچیدگی چند سیستم مختلف را مخفی می‌کند
    // و یک متد ساده در اختیار Client قرار می‌دهد.
    public class OrderFacade
    {
        private readonly Inventory _inventory;
        private readonly Payment _payment;
        private readonly Shipping _shipping;

        public OrderFacade()
        {
            _inventory = new Inventory();
            _payment = new Payment();
            _shipping = new Shipping();
        }

        public void PlaceOrder()
        {
            // مرحله اول: بررسی موجودی
            if (!_inventory.CheckStock())
            {
                Console.WriteLine("Product is not available.");
                return;
            }

            // مرحله دوم: پرداخت
            if (!_payment.Pay())
            {
                Console.WriteLine("Payment failed.");
                return;
            }

            // مرحله سوم: ارسال
            _shipping.Ship();

            Console.WriteLine("Order completed.");
        }
    }


    // ============================================
    // Client
    // ============================================
    //public class Program
    //{
    //    public static void Main()
    //    {
    //        // Client لازم نیست با Inventory،
    //        // Payment و Shipping مستقیماً کار کند.

    //        var orderFacade = new OrderFacade();

    //        // فقط یک متد ساده را صدا می‌زنیم.
    //        orderFacade.PlaceOrder();
    //    }
    //}
}