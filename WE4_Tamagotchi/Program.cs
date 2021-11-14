using System;
using System.Timers;

namespace WE4_Tamagotchi
{

    class Program
    {
        private static System.Timers.Timer myTimer;
        static void Main(string[] args)
        {
            SetTimer();

            Console.WriteLine("\nPress Enter to exit the application... \n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            myTimer.Stop();
            myTimer.Dispose();



        }

        public static void SetTimer()
        {
            myTimer = new System.Timers.Timer(1000);
            myTimer.Elapsed += OnTimedEvent;
            myTimer.AutoReset = true;
            myTimer.Enabled = true;

        }

        public static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("De tijd is {0:HH:mm:ss.fff},", e.SignalTime); ;
        }
    }
}
