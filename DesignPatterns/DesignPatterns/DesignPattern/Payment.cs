using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public abstract class Payment
    {
        public abstract void Pay(decimal amount);
    }

    public class CardPayment : Payment
    {
        public override void Pay(decimal amount)
        {
            Console.WriteLine("پرداخت با کارت: " + amount);
        }
    }

    public class ZarinPalPayment : Payment
    {
        public override void Pay(decimal amount)
        {
            Console.WriteLine("پرداخت با زرین پال: " + amount);
        }
    }

    public abstract class PaymentCreator
    {
        protected abstract Payment CreatePayment();

        public void PaymentPay(decimal amount)
        {
            Payment payment = CreatePayment();
            payment.Pay(amount);
        }
    }


    public class CardPaymentCreator : PaymentCreator
    {
        protected override Payment CreatePayment()
        {
            return new CardPayment();
        }
    }

    public class ZarinPalPaymentCreator : PaymentCreator
    {
        protected override Payment CreatePayment()
        {
            return new ZarinPalPayment();
        }
    }

    class ProgramPayment
    {
        //static void Main()
        //{
        //    PaymentCreator zarinPalPaymentCreator = new ZarinPalPaymentCreator();
        //    zarinPalPaymentCreator.PaymentPay(100);


        //    PaymentCreator cardPaymentCreator = new CardPaymentCreator();
        //    cardPaymentCreator.PaymentPay(200);
        //}
    }
}
