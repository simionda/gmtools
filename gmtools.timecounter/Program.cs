using gmtools.time;
using System;

namespace gmtools.timecounter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This will start at midnight, and increment 1 second, then display the result, through 86,400 seconds (full day)");
            Console.Write("Press any key to start");
            Console.ReadKey();

            Console.WriteLine("");

            var currentTime = new FaerunCalendar();
            for (var ctr = 0; ctr <= 86400; ctr++)
            {
                Console.WriteLine($"Counter: {ctr}, Current Time: {currentTime.ToString()}");
                currentTime.AddSecond();
            }

            Console.WriteLine("");
            Console.WriteLine("Finished");
            Console.Write("Press any key to close");
            Console.ReadKey();
        }
    }
}
