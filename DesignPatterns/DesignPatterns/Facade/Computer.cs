using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Computer
    {
        public class CPU
        {
            public bool Start()
            {
                Console.WriteLine("CPU Started");

                return true;
            }
        }
        public class Memory
        {
            public bool Load()
            {
                Console.WriteLine("Memory Loaded");

                return true;
            }
        }
        public class HardDrive
        {
            public bool Read()
            {
                Console.WriteLine("HardDrive Readed");

                return true;
            }
        }
        public class ComputerFacade
        {
            private readonly CPU _cpu;
            private readonly Memory _memory;
            private readonly HardDrive _hardDrive;

            public ComputerFacade()
            {
                _cpu = new CPU();
                _memory = new Memory();
                _hardDrive = new HardDrive();
            }
            public void StartComputer()
            {
                if (!_cpu.Start())
                {
                    Console.WriteLine("CPU Is Not Started");
                    return;
                }
                if (!_memory.Load())
                {
                    Console.WriteLine("Memory Is Not Loaded");
                    return;
                }
                if (!_hardDrive.Read())
                {
                    Console.WriteLine("HardDrive Is Not Readed");
                    return;
                }
                Console.WriteLine("Computer  Is Started Succesful");
            }
        }
        public class ComputerProgram
        {
            public static void Main()
            {
                ComputerFacade computer = new ComputerFacade();
                computer.StartComputer();
            }
        }
    }
}
