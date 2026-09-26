using System;
using System.Collections.Generic;

// Subject (WeatherStation)
public class WeatherStation
{
    private List<IObserver> observers = new List<IObserver>();
    private string currentWeather;

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(currentWeather);
        }
    }

    public void SetWeather(string newWeather)
    {
        currentWeather = newWeather;
        NotifyObservers();
    }
}

// Observer Interface
public interface IObserver
{
    void Update(string weather);
}

// Concrete Observer (DisplayDevice)
public class DisplayDevice : IObserver
{
    private string displayLocation;

    public DisplayDevice(string location)
    {
        displayLocation = location;
    }

    public void Update(string weather)
    {
        Console.WriteLine($"Display at {displayLocation} updated. Current weather: {weather}");
    }
}

// Client Code
class Program
{
    static void Main()
    {
        WeatherStation weatherStation = new WeatherStation();

        DisplayDevice mobileApp = new DisplayDevice("Mobile App");
        DisplayDevice website = new DisplayDevice("Website");
        DisplayDevice dedicatedDevice = new DisplayDevice("Dedicated Device");

        weatherStation.AddObserver(mobileApp);
        weatherStation.AddObserver(website);
        weatherStation.AddObserver(dedicatedDevice);

        weatherStation.SetWeather("Sunny"); // All displays should update
        weatherStation.SetWeather("Rainy"); // All displays should update
    }
}
