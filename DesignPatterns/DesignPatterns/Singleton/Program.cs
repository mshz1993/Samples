using System;

public class Singleton_Class
{
    private static Singleton_Class instance;
    private static readonly object lockObject = new object();

    private Singleton_Class()
    {
        Console.WriteLine("Singleton is Instantiated.");
    }

    public static Singleton_Class GetInstance()
    {
        lock (lockObject)//بیش از یک Thread نمیتواند همزمان وارد شود
        {
            if (instance == null)
                instance = new Singleton_Class();

            return instance;
        }
    }

    public void DoSomething()
    {
        Console.WriteLine("Something is Done.");
    }
}

class Program
{
    //static void Main(string[] args)
    //{
    //    Singleton_Class.GetInstance().DoSomething();
    //}
}