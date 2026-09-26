using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public abstract class Shipping
    {
        public abstract void SendOrder();
    }


    public class PostShipping : Shipping
    {
        public override void SendOrder()
        {
            Console.WriteLine("Post Shipping");
        }
    }


    public class TipaxShipping : Shipping
    {
        public override void SendOrder()
        {
            Console.WriteLine("Tipax Shipping");
        }
    }


    public abstract class ShippingCreator
    {
        protected abstract Shipping CreateShipping();

        public void SendOrderShipping()
        {
            Shipping shipping = CreateShipping();
            shipping.SendOrder();
        }
    }

    public class PostShippingCreator : ShippingCreator
    {
        protected override Shipping CreateShipping()
        {
            return new PostShipping();
        }
    }

    public class TipaxShippingCreator : ShippingCreator
    {
        protected override Shipping CreateShipping()
        {
            return new TipaxShipping();
        }
    }

    public class Use
    {
        public static void Main()
        {
            ShippingCreator postShippingCreator = new PostShippingCreator();
            postShippingCreator.SendOrderShipping();


            ShippingCreator tipaxShippingCreator = new TipaxShippingCreator();
            tipaxShippingCreator.SendOrderShipping();
        }

    }
}
