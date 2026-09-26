using System;

// Command interface
interface ICommand
{
    void Execute();
}

// Light class and its corresponding command classes
class Light
{
    public void On()
    {
        Console.WriteLine("Light is on");
    }

    public void Off()
    {
        Console.WriteLine("Light is off");
    }
}

class LightOnCommand : ICommand
{
    private readonly Light _light;

    public LightOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.On();
    }
}

class LightOffCommand : ICommand
{
    private readonly Light _light;

    public LightOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.Off();
    }
}

// Stereo and its command classes
class Stereo
{
    public void On()
    {
        Console.WriteLine("Stereo is on");
    }

    public void Off()
    {
        Console.WriteLine("Stereo is off");
    }

    public void SetCD()
    {
        Console.WriteLine("Stereo is set for CD input");
    }

    public void SetVolume(int volume)
    {
        Console.WriteLine($"Stereo volume set to {volume}");
    }
}

class StereoOffCommand : ICommand
{
    private readonly Stereo _stereo;

    public StereoOffCommand(Stereo stereo)
    {
        _stereo = stereo;
    }

    public void Execute()
    {
        _stereo.Off();
    }
}

class StereoOnWithCDCommand : ICommand
{
    private readonly Stereo _stereo;

    public StereoOnWithCDCommand(Stereo stereo)
    {
        _stereo = stereo;
    }

    public void Execute()
    {
        _stereo.On();
        _stereo.SetCD();
        _stereo.SetVolume(11);
    }
}

// Simple remote control with one button
class SimpleRemoteControl
{
    private ICommand _slot; // only one button

    public SimpleRemoteControl()
    {
    }

    public void SetCommand(ICommand command)
    {
        // set the command the remote will execute
        _slot = command;
    }

    public void ButtonWasPressed()
    {
        _slot.Execute();
    }
}

// Driver class
class RemoteControlTest
{
    static void Main(string[] args)
    {
        SimpleRemoteControl remote = new SimpleRemoteControl();
        Light light = new Light();
        Stereo stereo = new Stereo();

        // We can change command dynamically
        remote.SetCommand(new LightOnCommand(light));
        remote.ButtonWasPressed();
        remote.SetCommand(new StereoOnWithCDCommand(stereo));
        remote.ButtonWasPressed();
        remote.SetCommand(new StereoOffCommand(stereo));
        remote.ButtonWasPressed();
    }
}
