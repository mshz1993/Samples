using System;

public interface IDevice
{
    void TurnOn();
    void TurnOff();
}

public class TV : IDevice
{
    public void TurnOn()
    {
        Console.WriteLine("TV روشن شد");
    }

    public void TurnOff()
    {
        Console.WriteLine("TV خاموش شد");
    }
}

public abstract class RemoteControl
{
    protected IDevice _device;

    protected RemoteControl(IDevice device)
    {
        _device = device;
    }

    public abstract void TurnOn();
    public abstract void TurnOff();
}

public class BasicRemote : RemoteControl
{
    public BasicRemote(IDevice device)
        : base(device)
    {
    }

    public override void TurnOn()
    {
        _device.TurnOn();
    }

    public override void TurnOff()
    {
        _device.TurnOff();
    }
}

public class Program
{
    public static void Main()
    {
        IDevice tv = new TV();

        RemoteControl remote = new BasicRemote(tv);

        remote.TurnOn();
        remote.TurnOff();
    }
}