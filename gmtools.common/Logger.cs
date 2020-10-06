using System;

namespace gmtools.common
{
    public static class Logger
    {
        public static bool Enabled { get; set; }
        public static void Log(string msg)
        {
            if (Enabled) Console.WriteLine(msg);
        }
    }
}
