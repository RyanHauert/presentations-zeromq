using System.Diagnostics;

namespace ZeroMQDemo
{
    public static class Runner
    {
        public static void Start(string arguments)
        {
            Process.Start("ZeroMQRunner.exe", arguments);
        }
    }
}