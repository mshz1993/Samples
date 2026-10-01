using System;

public interface IMessageSender
{
    void Send(string message);
}

public class OldSmsService
{
    public void SendSms(string text)
    {
        Console.WriteLine($"SMS: {text}");
    }
}

public class SmsAdapter : IMessageSender
{
    private readonly OldSmsService _smsService;

    public SmsAdapter()
    {
        _smsService = new OldSmsService();
    }

    public void Send(string message)
    {
        _smsService.SendSms(message);
    }
}

//public class Program
//{
//    public static void Main()
//    {
//        IMessageSender sender = new SmsAdapter();

//        sender.Send("Hello");
//    }
//}