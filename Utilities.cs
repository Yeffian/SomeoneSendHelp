using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeoneSendHelp
{
    internal static class Utilities
    {
        public static void WriteColor(ConsoleColor c, object msg)
        {
            Console.ForegroundColor = c;
            Console.WriteLine(msg.ToString());
            Console.ResetColor();
        }
    }
}
