using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class OldPayment
    {
        public void PayByCard(string cardNumber, decimal amount)
        {
            Console.WriteLine($"Card Payment: {cardNumber} - {amount}");
        }
    }
    public interface IPayment
    {
        void Pay(string cardNumber, decimal amount);
    }

    public class PaymentAdapter : IPayment
    {
        private readonly OldPayment _oldPayment;


        public PaymentAdapter()
        {
            _oldPayment = new OldPayment();
        }

        public void Pay(string cardNumber, decimal amount)
        {
            _oldPayment.PayByCard(cardNumber, amount);
        }
    }

    public class PaymentProgram
    {
        public static void Main()
        {
            IPayment adapter = new PaymentAdapter();
            adapter.Pay("Melli", 125000);
        }
    }
}
