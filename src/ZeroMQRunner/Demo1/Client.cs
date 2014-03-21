using System;
using System.Text;
using System.Threading;
using fszmq;

namespace ZeroMQRunner.Demo1
{
    public class Client : Endpoint, IDemo1Endpoint
    {
        public void Execute()
        {
            using (var context = new Context())
            using (var requester = context.Request())
            {
                requester.Connect("tcp://localhost:5555");
                SendRequests(requester);
            }
        }

        private static void SendRequests(Socket requester)
        {
            var message = Encoding.Unicode.GetBytes("Hello");
            while (true)
            {
                requester.Send(message);
                var response = requester.Recv();
                Console.WriteLine("Response: {0}", Encoding.Unicode.GetString(response));
                Thread.Sleep(1000);
            }
        }

        public void PositionWindow()
        {
            ConsoleApp.MoveWindow(800, 100);
        }
    }
}