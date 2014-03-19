using System.Diagnostics;

namespace ZeroMQDemo
{
    public static class Server
    {
        public static void Start(string arguments)
        {
            Process.Start("Server.exe", arguments);
        }
    }
}