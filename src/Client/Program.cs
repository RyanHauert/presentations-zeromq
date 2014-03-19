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
            MoveWindow(800, 200);

            var commands = Bootstrap(Assembly.GetExecutingAssembly());
            var executor = new CommandExecutor(commands);
            if (args.Length > 0)
                executor.Execute(args);
            else
                executor.Execute("help");
        }
    }
}
