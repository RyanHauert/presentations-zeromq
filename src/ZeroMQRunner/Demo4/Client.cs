using System;
using System.Text;
using System.Threading;
using fszmq;
using FubuCore;

namespace ZeroMQRunner.Demo4
{
    public class Client : Endpoint, IDemo4Endpoint
    {
        public void Execute(Demo4Input input)
        {
            using (var context = new Context())
            using (var socket = context.Request())
            {
                socket.Connect("tcp://localhost:5559");
                SendRequests(socket, input.NodeNumberFlag);
            }
        }

        private static void SendRequests(Socket requester, string nodeId)
        {
            var random = new Random();
            var message = Encoding.Unicode.GetBytes("Hello from client {0}".ToFormat(nodeId));
            int nodeNumber = int.Parse(nodeId);
            while (true)
            {
                requester.Send(message);
                var response = requester.Recv();
                Console.WriteLine(Encoding.Unicode.GetString(response));
                Thread.Sleep(random.Next(800, 1200) * nodeNumber);
            }
        }

        public void PositionWindow(Demo4Input input)
        {
            Console.SetWindowSize(45, 15);
            Console.SetBufferSize(45, 15);

            int clientNumber = int.Parse(input.NodeNumberFlag);
            ConsoleApp.MoveWindow(100 + (200 * (clientNumber - 1)), 100);
        }
    }
}