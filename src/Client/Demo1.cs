using System;
using System.Text;
using System.Threading;
using fszmq;
using FubuCore.CommandLine;

namespace Client
{
    [CommandDescription("Runs the first demo client", Name = "demo1")]
    public class Demo1 : FubuCommand<Demo1Input>
    {
        public override bool Execute(Demo1Input input)
        {
            using (var context = new Context())
            using (var socket = context.Request())
            {
                socket.Connect("tcp://localhost:5555");
                SendRequests(socket);
            }

            return true;
        }

        private static void SendRequests(Socket socket)
        {
            var message = Encoding.Unicode.GetBytes("Hello");
            while (true)
            {
                socket.Send(message);
                var response = socket.Recv();
                Console.WriteLine("Response: {0}", Encoding.Unicode.GetString(response));
                Thread.Sleep(1000);
            }
        }
    }

    public class Demo1Input
    {
    }
}