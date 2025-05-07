using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewContactManager
{
    public class ConsoleUtil
    {
        public static void WriteLine(string inputString, ConsoleColor color)
        {
            Console.WriteLine();
            Console.ForegroundColor = color;
            Console.WriteLine(inputString);
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void Write(string inputString, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(inputString);
            Console.ResetColor();
        }
    }
}