using System;
using System.Text;
using System.Threading;
using fszmq;
using FubuCore;
using FubuCore.CommandLine;

namespace Server
{
    [CommandDescription("Runs the second demo server", Name = "demo2")]
    public class Demo2 : FubuCommand<Demo2Input>
    {
        public override bool Execute(Demo2Input input)
        {
            using (var context = new Context())
            using (var publisher = context.Publish())
            {
                publisher.Bind("tcp://*:5556");
                PublishMessages(publisher);
            }

            return true;
        }

        private static void PublishMessages(Socket publisher)
        {
            var random = new Random();
            while (true)
            {
                // Generate some accurate weather data
                int zip = random.Next(100000);
                int temp = random.Next(-80, 135);
                int humidity = random.Next(10, 100);

                // Generate frequent updates for 84101
                if (random.Next(0, 4) == 0)
                    zip = 84101;

                string message = "{0}|{1}|{2}".ToFormat(zip, temp, humidity);
                Console.WriteLine("Publishing: {0}", message);

                publisher.Send(Encoding.Unicode.GetBytes(message));
                Thread.Sleep(500);
            }
        }
    }

    public class Demo2Input
    {
    }
}