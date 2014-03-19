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
            using (var responder = context.Response())
            {
                responder.Bind("tcp://*:5555");
                HandleRequests(responder);
            }

            return true;
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

    public class Demo1Input
    {
    }
}