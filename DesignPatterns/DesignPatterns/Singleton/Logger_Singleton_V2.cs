using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    /// <summary>
    /// در این حالت موقع اولین استفاده از کلاس توسط Runtimeنمونه ساخته می شود
    /// و تضمین میدهد که فقط یک نمونه ایجاد میکند و نیاز به استفاده از 
    /// Lock نیست
    /// </summary>
    public class Logger_Singleton_V2
    {
        private static readonly Logger_Singleton_V2 _instance =
            new Logger_Singleton_V2();

        private Logger_Singleton_V2()
        {
        }

        public static Logger_Singleton_V2 Instance
        {
            get
            {
                return _instance;
            }
        }

        public void Log(string message)
        {
            Console.WriteLine($"LOG: {message}");
        }
    }

    public class LoggerV2_Main
    {
        public static void Main()
        {
            var logger1 = Logger_Singleton_V2.Instance;
            var logger2 = Logger_Singleton_V2.Instance;

            Console.WriteLine(logger1 == logger2);

            Logger_Singleton_V2.Instance.Log("Write Log");
        }
    }
}
