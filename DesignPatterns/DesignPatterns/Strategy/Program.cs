using System;

// Strategy Interface
public interface IPaymentStrategy
{
    void ProcessPayment(float amount);
}

// Concrete Strategies
public class PayPalPayment : IPaymentStrategy
{
    public void ProcessPayment(float amount)
    {
        Console.WriteLine($"Processing PayPal payment of {amount} dollars.");
        // Additional PayPal-specific logic
    }
}

public class CreditCardPayment : IPaymentStrategy
{
    public void ProcessPayment(float amount)
    {
        Console.WriteLine($"Processing Credit Card payment of {amount} dollars.");
        // Additional Credit Card-specific logic
    }
}

public class BitcoinPayment : IPaymentStrategy
{
    public void ProcessPayment(float amount)
    {
        Console.WriteLine($"Processing Bitcoin payment of {amount} dollars.");
        // Additional Bitcoin-specific logic
    }
}

// Context
public class PaymentContext
{
    private IPaymentStrategy paymentStrategy;

    public PaymentContext(IPaymentStrategy strategy)
    {
        this.paymentStrategy = strategy;
    }

    public void SetPaymentStrategy(IPaymentStrategy strategy)
    {
        this.paymentStrategy = strategy;
    }

    public void ProcessPayment(float amount)
    {
        paymentStrategy.ProcessPayment(amount);
    }
}

// Client Code
class Program
{
    static void Main()
    {
        PaymentContext paymentContext = new PaymentContext(new PayPalPayment());

        paymentContext.ProcessPayment(100.0f);

        // Switching the payment method at runtime
        paymentContext.SetPaymentStrategy(new BitcoinPayment());
        paymentContext.ProcessPayment(50.0f);
    }
}
