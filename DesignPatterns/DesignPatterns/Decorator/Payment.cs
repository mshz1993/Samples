using static Decorator.Payment;

namespace Decorator
{
    public class Payment
    {
        public interface IPayment
        {
            void Pay();
        }
        public class CreditCardPayment : IPayment
        {
            public void Pay()
            {
                Console.WriteLine("Payment completed");
            }
        }
        public class LoggingPaymentDecorator : IPayment
        {
            private IPayment _payment;

            public LoggingPaymentDecorator(IPayment payment)
            {
                _payment = payment;
            }

            public void Pay()
            {
                Console.WriteLine("Logging payment...");
                _payment.Pay();
            }
        }
    }
    //public class Program_Pay()
    //{
    //    public static void Main()
    //    {
    //        IPayment creditPayment = new CreditCardPayment();
    //        creditPayment = new LoggingPaymentDecorator(creditPayment);
    //        creditPayment.Pay();
    //    }
    //}
}
