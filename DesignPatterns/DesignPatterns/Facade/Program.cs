using System;

// Subsystem 1
class Engine
{
    public void Start()
    {
        Console.WriteLine("Engine started");
    }

    public void Stop()
    {
        Console.WriteLine("Engine stopped");
    }
}

// Subsystem 2
class Lights
{
    public void TurnOn()
    {
        Console.WriteLine("Lights on");
    }

    public void TurnOff()
    {
        Console.WriteLine("Lights off");
    }
}

// Facade
class Car
{
    private Engine engine = new Engine();
    private Lights lights = new Lights();

    public void StartCar()
    {
        engine.Start();
        lights.TurnOn();
        Console.WriteLine("Car is ready to drive");
    }

    public void StopCar()
    {
        lights.TurnOff();
        engine.Stop();
        Console.WriteLine("Car has stopped");
    }
}

class Program
{
    static void Main()
    {
        // Using the Facade to start and stop the car
        Car car = new Car();
        car.StartCar();
        // Simulate some driving
        car.StopCar();
    }
}
