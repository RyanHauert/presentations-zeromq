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
            DefaultExecution(args);
        }
    }
}
