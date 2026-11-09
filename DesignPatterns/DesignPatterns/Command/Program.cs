
using System;

namespace CommandPatternExample
{
    // 1. قرارداد مشترک تمام فرمان‌ها
    public interface ICommand
    {
        void Execute();
    }

    // 2. دریافت‌کننده؛ کاری را که باید انجام شود انجام می‌دهد
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("Light is ON");
        }

        public void TurnOff()
        {
            Console.WriteLine("Light is OFF");
        }
    }

    // 3. فرمان روشن‌کردن چراغ
    public class TurnOnCommand : ICommand
    {
        private readonly Light _light;

        public TurnOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOn();
        }
    }

    // 4. فرمان خاموش‌کردن چراغ
    public class TurnOffCommand : ICommand
    {
        private readonly Light _light;

        public TurnOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOff();
        }
    }

    // 5. اجراکننده فرمان
    public class RemoteControl
    {
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void PressButton()
        {
            _command.Execute();
        }
    }

    // 6. اجرای برنامه
    internal class Program
    {
        static void Main(string[] args)
        {
            Light light = new Light();
            RemoteControl remote = new RemoteControl();

            // تنظیم فرمان روشن‌کردن
            remote.SetCommand(new TurnOnCommand(light));
            remote.PressButton();

            // تغییر فرمان به خاموش‌کردن
            remote.SetCommand(new TurnOffCommand(light));
            remote.PressButton();

            Console.ReadKey();
        }
    }
}
