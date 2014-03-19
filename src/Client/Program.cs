using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core;
using FubuCore.CommandLine;

namespace Client
{
    class Program : ConsoleApp
    {
        static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                int clientNumber = int.Parse(args[1]);
                MoveWindow(800 + (25 * (clientNumber - 1)), 200 * clientNumber);
            }

            DefaultExecution(args);
            Console.ReadKey();
        }
    }
}
