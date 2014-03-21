using System.Collections.Generic;
using System.Diagnostics;

namespace ZeroMQDemo
{
    public static class Runner
    {
        private static readonly IList<Process> RunningProcesses = new List<Process>();

        public static void Start(string arguments)
        {
            var process = Process.Start("ZeroMQRunner.exe", arguments);
            RunningProcesses.Add(process);
        }

        public static void Reset()
        {
            RunningProcesses.Each(x =>
            {
                try
                {
                    x.Kill();
                }
                catch
                {
                }
            });
            RunningProcesses.Clear();
        }
    }
}