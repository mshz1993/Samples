using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FactoryDesignPattern
{
    public abstract class Message
    {
        public abstract void Send(string text);
    }

    public class SMSMessage : Message
    {
        public override void Send(string text)
        {
            Console.WriteLine(text);
        }
    }

    public class EmailMessage : Message
    {
        public override void Send(string text)
        {
            Console.WriteLine(text);
        }
    }


    public abstract class MessageCreator
    {
        protected abstract Message CreateMessage();

        public void SendMessage(string text)
        {
            Message message = CreateMessage();
            message.Send(text);
        }

    }

    public class SmsMessageCreator : MessageCreator
    {
        protected override Message CreateMessage()
        {
            return new SMSMessage();
        }
    }

    public class EmailMessageCreator : MessageCreator
    {
        protected override Message CreateMessage()
        {
            return new EmailMessage();
        }
    }



    //class ProgramMessage
    //{
    //    static void Main()
    //    {
    //        MessageCreator creator = new SmsMessageCreator();
    //        creator.SendMessage("سلام");

    //        creator = new EmailMessageCreator();
    //        creator.SendMessage("Hello");
    //    }
    //}
}
