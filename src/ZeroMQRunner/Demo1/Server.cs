using System;
using System.Text;
using fszmq;

namespace ZeroMQRunner.Demo1
{
    public class Server : IDemo1Endpoint
    {
        public string Type
        {
            get { return "server"; }
        }

        public void Execute()
        {
            ConsoleApp.MoveWindow(100, 200);

            using (var context = new Context())
            using (var responder = context.Response())
            {
                responder.Bind("tcp://*:5555");
                HandleRequests(responder);
            }
        }

        private static void HandleRequests(Socket responder)
        {
            while (true)
            {
                byte[] request = responder.Recv();
                string message = Encoding.Unicode.GetString(request);
                Console.WriteLine("Received: {0}", message);

                responder.Send(Encoding.Unicode.GetBytes("World"));
            }
        }
    }
}