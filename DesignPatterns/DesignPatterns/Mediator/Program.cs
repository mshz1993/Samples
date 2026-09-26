using System;
using System.Collections.Generic;

// Mediator Interface
public interface IChatMediator
{
    void SendMessage(User sender, string message);
}

// Concrete Mediator
public class ChatMediator : IChatMediator
{
    private List<User> users = new List<User>();

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void SendMessage(User sender, string message)
    {
        foreach (var user in users)
        {
            // Send message to all users except the sender
            if (user != sender)
                user.ReceiveMessage(message);
        }
    }
}

// Colleague Class
public class User
{
    private IChatMediator mediator;
    public string Name { get; }

    public User(IChatMediator mediator, string name)
    {
        this.mediator = mediator;
        Name = name;
        //mediator.AddUser(this);
    }

    public void SendMessage(string message)
    {
        Console.WriteLine($"{Name} sends: {message}");
        mediator.SendMessage(this, message);
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"{Name} receives: {message}");
    }
}

// Client Code
class Program
{
    static void Main()
    {
        IChatMediator mediator = new ChatMediator();

        User user1 = new User(mediator, "Alice");
        User user2 = new User(mediator, "Bob");
        User user3 = new User(mediator, "Charlie");

        user1.SendMessage("Hello, everyone!");
    }
}
