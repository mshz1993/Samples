using System;
using System.Collections.Generic;

namespace Decorator
{
    public class OrderSample
    {
        // ============================================
        // Component
        // ============================================
        // Interface مشترک بین Object اصلی و Decoratorها
        public interface IOrder
        {
            void Process();
        }


        // ============================================
        // Concrete Component
        // ============================================
        // Object اصلی که می‌خواهیم قابلیت‌های جدید
        // به آن اضافه کنیم.
        public class Order : IOrder
        {
            public void Process()
            {
                Console.WriteLine("Order processed");
            }
        }


        // ============================================
        // Concrete Decorator - Logging
        // ============================================
        // Decorator همان Interface اصلی را پیاده‌سازی می‌کند.
        //
        // نکته مهم:
        // یک IOrder داخل خودش نگه می‌دارد.
        //
        // بنابراین می‌تواند یک Order یا حتی یک
        // Decorator دیگر باشد.
        public class LoggingOrderDecorator : IOrder
        {
            private readonly IOrder _order;

            public LoggingOrderDecorator(IOrder order)
            {
                _order = order;
            }

            public void Process()
            {
                // قابلیت جدیدی که به Order اضافه کردیم
                Console.WriteLine("Logging order...");

                // اجرای Object اصلی یا Decorator قبلی
                _order.Process();
            }
        }


        // ============================================
        // Concrete Decorator - Notification
        // ============================================
        // یک Decorator دیگر برای اضافه کردن قابلیت
        // ارسال Notification
        public class NotificationOrderDecorator : IOrder
        {
            private readonly IOrder _order;

            public NotificationOrderDecorator(IOrder order)
            {
                _order = order;
            }

            public void Process()
            {
                // ابتدا Object قبلی اجرا می‌شود
                _order.Process();

                // سپس قابلیت Notification اضافه می‌شود
                Console.WriteLine("Notification sent");
            }
        }


        // ============================================
        // Client
        // ============================================
        public class OrderProgram
        {
            public static void Main()
            {
                // Object اصلی
                IOrder order = new Order();


                // اضافه کردن Logging به Order
                //
                // ساختار:
                //
                // LoggingDecorator
                //       ↓
                //      Order
                order = new LoggingOrderDecorator(order);


                // اضافه کردن Notification روی Decorator قبلی
                //
                // ساختار نهایی:
                //
                // NotificationDecorator
                //          ↓
                // LoggingDecorator
                //          ↓
                //        Order
                order = new NotificationOrderDecorator(order);


                // اجرای کل زنجیره
                order.Process();
            }
        }
    }
}