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
            using (var requester = context.Request())
            {
                requester.Connect("tcp://localhost:5555");
                SendRequests(requester);
            }

            return true;
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

    public class Demo1Input
    {
    }
}