
using System;
using System.Collections.Generic;

namespace MediatorPatternExample
{
    // 1. قرارداد میانجی
    public interface IChatMediator
    {
        void SendMessage(string message, User sender);
        void RegisterUser(User user);
    }

    // 2. میانجی واقعی؛ مدیریت ارتباط کاربران
    public class ChatRoom : IChatMediator
    {
        private readonly List<User> _users = new List<User>();

        public void RegisterUser(User user)
        {
            _users.Add(user);
        }

        public void SendMessage(string message, User sender)
        {
            foreach (User user in _users)
            {
                // پیام برای فرستنده ارسال نمی‌شود
                if (user != sender)
                {
                    user.ReceiveMessage(message, sender.Name);
                }
            }
        }
    }

    // 3. کاربر
    public class User
    {
        private readonly IChatMediator _mediator;

        public string Name { get; }

        public User(string name, IChatMediator mediator)
        {
            Name = name;
            _mediator = mediator;
        }

        public void SendMessage(string message)
        {
            Console.WriteLine($"{Name} sends: {message}");
            _mediator.SendMessage(message, this);
        }

        public void ReceiveMessage(string message, string senderName)
        {
            Console.WriteLine(
                $"{Name} received from {senderName}: {message}");
        }
    }

    // 4. اجرای برنامه
    internal class Program
    {
        static void Main(string[] args)
        {
            IChatMediator chatRoom = new ChatRoom();

            User ali = new User("Ali", chatRoom);
            User sara = new User("Sara", chatRoom);
            User reza = new User("Reza", chatRoom);

            chatRoom.RegisterUser(ali);
            chatRoom.RegisterUser(sara);
            chatRoom.RegisterUser(reza);

            ali.SendMessage("Hello everyone!");

            Console.ReadKey();
        }
    }
}
