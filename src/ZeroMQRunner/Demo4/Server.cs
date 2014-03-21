using System;
using System.Text;
using System.Threading;
using fszmq;
using FubuCore;

namespace ZeroMQRunner.Demo4
{
    public class Server : Endpoint, IDemo4Endpoint
    {
        public void Execute(Demo4Input input)
        {
            using (var context = new Context())
            using (var socket = context.Response())
            {
                socket.Connect("tcp://localhost:5560");
                HandleRequests(socket, input.NodeNumberFlag);
            }
        }

        private static void HandleRequests(Socket responder, string nodeId)
        {
            var random = new Random();
            while (true)
            {
                byte[] request = responder.Recv();
                string message = Encoding.Unicode.GetString(request);
                Console.WriteLine(message);

                // Simulate work
                //Thread.Sleep(random.Next(100, 500));

                responder.Send(Encoding.Unicode.GetBytes("Hello from server {0}".ToFormat(nodeId)));
            }
        }

        public void PositionWindow(Demo4Input input)
        {
            int clientNumber = int.Parse(input.NodeNumberFlag);
            ConsoleApp.MoveWindow(100 + (200 * (clientNumber - 1)), 600);
        }
    }
}