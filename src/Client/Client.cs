using System.Diagnostics;

namespace ZeroMQDemo
{
    public static class Client
    {
        public static void Start(string arguments)
        {
            Process.Start("Client.exe", arguments);
        }
    }
}