using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Core;
using FubuCore.CommandLine;

namespace Server
{
    class Program : ConsoleApp
    {
        static void Main(string[] args)
        {
            MoveWindow(100, 200);
            DefaultExecution(args);
        }
    }
}
