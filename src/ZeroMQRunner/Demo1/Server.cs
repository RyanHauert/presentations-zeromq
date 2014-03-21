using System;
using System.Text;
using fszmq;

namespace ZeroMQRunner.Demo1
{
    public class Server : Endpoint, IDemo1Endpoint
    {
        public void Execute()
        {
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

        public void PositionWindow()
        {
            Console.SetWindowSize(45, 20);
            Console.SetBufferSize(45, 20);
            ConsoleApp.MoveWindow(25, 100);
        }
    }
}