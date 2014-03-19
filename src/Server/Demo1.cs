using System;
using System.Text;
using fszmq;
using FubuCore.CommandLine;

namespace Server
{
    [CommandDescription("Runs the first demo server", Name = "demo1")]
    public class Demo1 : FubuCommand<Demo1Input>
    {
        public override bool Execute(Demo1Input input)
        {
            using (var context = new Context())
            using (var socket = context.Response())
            {
                socket.Bind("tcp://*:5555");
                HandleRequests(socket);
            }

            return true;
        }

        private static void HandleRequests(Socket socket)
        {
            while (true)
            {
                byte[] request = socket.Recv();
                string message = Encoding.Unicode.GetString(request);
                Console.WriteLine("Received: {0}", message);

                socket.Send(Encoding.Unicode.GetBytes("World")); 
            }
        }
    }

    public class Demo1Input
    {
    }
}