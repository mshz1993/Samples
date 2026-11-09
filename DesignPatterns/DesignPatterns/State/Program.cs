
using System;

namespace StatePatternExample
{
    // 1. قرارداد وضعیت‌های سفارش
    public interface IOrderState
    {
        void Process(Order order);
    }

    // 2. وضعیت سفارش جدید
    public class NewOrderState : IOrderState
    {
        public void Process(Order order)
        {
            Console.WriteLine("Order is being processed.");

            // پس از پردازش، وضعیت سفارش تغییر می‌کند
            order.SetState(new ShippedOrderState());
        }
    }

    // 3. وضعیت سفارش ارسال‌شده
    public class ShippedOrderState : IOrderState
    {
        public void Process(Order order)
        {
            Console.WriteLine("Order has already been shipped.");
        }
    }

    // 4. وضعیت سفارش لغوشده
    public class CancelledOrderState : IOrderState
    {
        public void Process(Order order)
        {
            Console.WriteLine("Cancelled order cannot be processed.");
        }
    }

    // 5. کلاس اصلی سفارش
    public class Order
    {
        private IOrderState _state;

        public Order()
        {
            // وضعیت اولیه
            _state = new NewOrderState();
        }

        public void SetState(IOrderState state)
        {
            _state = state;
        }

        public void Process()
        {
            _state.Process(this);
        }

        public void Cancel()
        {
            SetState(new CancelledOrderState());
        }
    }

    // 6. اجرای برنامه
    internal class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();

            order.Process();
            order.Process();

            Order cancelledOrder = new Order();
            cancelledOrder.Cancel();
            cancelledOrder.Process();

            Console.ReadKey();
        }
    }
}
