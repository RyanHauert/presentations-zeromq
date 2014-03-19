using System;
using System.Text;
using System.Threading;
using fszmq;
using FubuCore.CommandLine;
using FubuCore.Configuration;

namespace Client
{
    [CommandDescription("Runs the second demo client", Name = "demo2")]
    public class Demo2 : FubuCommand<Demo2Input>
    {
        public override bool Execute(Demo2Input input)
        {
            using (var context = new Context())
            using (var subscriber = context.Subscribe())
            {
                AddSubscription(subscriber, input.ZipCode);
                subscriber.Connect("tcp://localhost:5556");

                ListenForEvents(subscriber);
            }

            return true;
        }

        private void AddSubscription(Socket subscriber, string zipCode)
        {
            if (zipCode == "0")
                zipCode = String.Empty;
            var topic = Encoding.Unicode.GetBytes(zipCode);
            subscriber.Subscribe(new[] { topic });
        }

        private static void ListenForEvents(Socket subscriber)
        {
            while (true)
            {
                var message = subscriber.Recv();
                var values = Encoding.Unicode.GetString(message).Split('|');
                Console.WriteLine("ZipCode: {0}, Temp: {1}, Humidity: {2}", values[0], values[1], values[2]);
            }
        }
    }

    public class Demo2Input
    {
        public string ClientId { get; set; }
        public string ZipCode { get; set; }
    }
}