using System;

// Target Interface
public interface ILegacyService
{
    void LegacyRequest();
}

// Adaptee
public class NewService
{
    public void NewRequest()
    {
        Console.WriteLine("Executing NewService.NewRequest()");
    }
}

// Adapter
public class Adapter : ILegacyService
{
    private readonly NewService newService;

    public Adapter(NewService newService)
    {
        this.newService = newService;
    }

    public void LegacyRequest()
    {
        newService.NewRequest();
    }
}

// Client Code
class Program
{
    static void Main()
    {
        // Using Adapter
        NewService newService = new NewService();
        ILegacyService legacyServiceAdapter = new Adapter(newService);

        // Client invokes LegacyRequest without knowing about NewService
        legacyServiceAdapter.LegacyRequest();
    }
}
