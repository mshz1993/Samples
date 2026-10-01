using System;

namespace Decorator
{
    // Component
    public interface IMessage
    {
        void Send();
    }

    // Concrete Component
    public class SMS : IMessage
    {
        public void Send()
        {
            Console.WriteLine("SMS Sent");
        }
    }

    // Decorator
    public class LoggingDecorator : IMessage
    {
        private readonly IMessage message;

        public LoggingDecorator(IMessage message)
        {
            this.message = message;
        }

        public void Send()
        {
            Console.WriteLine("Log: Sending message");

            message.Send();
        }
    }

    //public class Program
    //{
    //    public static void Main()
    //    {
    //        IMessage message = new SMS();

    //        message = new LoggingDecorator(message);

    //        message.Send();
    //    }
    //}
}