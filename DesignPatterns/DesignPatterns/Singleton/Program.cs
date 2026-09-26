using System;

public class Singleton
{
    // static class
    private static Singleton instance;

    private Singleton()
    {
        Console.WriteLine("Singleton is Instantiated.");
    }

    public static Singleton GetInstance()
    {
        if (instance == null)
            instance = new Singleton();
        return instance;
    }

    public void DoSomething()
    {
        Console.WriteLine("Something is Done.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Singleton.GetInstance().DoSomething();
    }
}
