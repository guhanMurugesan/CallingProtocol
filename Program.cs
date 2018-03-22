using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallingProtocol
{
    class Program
    {
        /// <summary>
        /// Coding without calling protocol
        ///    1.Client's are not aware of which method to call in sequence. if client calls Drive() before Ignite, its not gonna work 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ITrigger trigger = new Engine();
            trigger.Ignite().Drive().GetTemperature();
            Console.ReadKey();
        }

        class Engine:ITrigger,IRunnable,IRunning
        {
            public IRunnable Ignite()
            {
                Console.WriteLine("ignited");
                IRunnable obj = new Engine();
                return obj;
            }

            public IRunning Drive()
            {
                Console.WriteLine("running");
                IRunning obj = new Engine();
                return obj;
            }

            public void GetTemperature()
            {
                Console.WriteLine("30 degree");
            }
        }

        interface ITrigger
        {
            IRunnable Ignite();
        }

        interface IRunnable
        {
            IRunning Drive();
        }

        interface IRunning
        {
            void GetTemperature();
        }

    }
}
