using System;
using System.Text;
using System.Threading;
using fszmq;

namespace ZeroMQRunner.Demo1
{
    public class Client : IDemo1Endpoint
    {
        public string Type
        {
            get { return "client"; }
        }

        public void Execute()
        {
            ConsoleApp.MoveWindow(800, 200);

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
    }
}