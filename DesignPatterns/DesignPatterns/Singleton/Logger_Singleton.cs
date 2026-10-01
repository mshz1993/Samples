using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    /// <summary>
    /// به روش Thread-Safe یعنی فقط یک ترد میتواند درآن واحد نمونه بسازد 
    /// </summary>
    public class Logger_SingletonWithlock
    {
        private static Logger_SingletonWithlock _instance;
        private static readonly object lockObject = new object();

        private Logger_SingletonWithlock()
        {

        }
        public static Logger_SingletonWithlock Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (_instance is null)
                    {
                        _instance = new Logger_SingletonWithlock();
                    }
                    return _instance;
                }
            }
        }
        public void DoSomething()
        {
            Console.WriteLine("Something is Done.");
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
   //public class Logger_Main
   // {
   //     public static void Main()
   //     {
   //         var logger1 = Logger_SingletonWithlock.Instance;
   //         var logger2 = Logger_SingletonWithlock.Instance;

   //         Console.WriteLine(logger1 == logger2);

   //         Logger_SingletonWithlock.Instance.DoSomething();


   //         logger1.Log("Write Log");
   //         logger2.Log("Write Log2");
   //     }
   // }


}
