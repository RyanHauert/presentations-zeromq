using System.Threading;
using FubuCore.CommandLine;

namespace ZeroMQDemo
{
    [CommandDescription("Demo 4: Extended request/reply with a proxy", Name = "demo4")]
    public class Demo4Command : FubuCommand<Demo4Input>
    {
        public override bool Execute(Demo4Input input)
        {
            Runner.Start("demo4 proxy");
            Runner.Start("demo4 server -n 1");
            Runner.Start("demo4 server -n 2");
            Runner.Start("demo4 server -n 3");

            // Let the servers start up
            Thread.Sleep(100);
            Runner.Start("demo4 client -n 1");
            Runner.Start("demo4 client -n 2");
            Runner.Start("demo4 client -n 3");

            return true;
        }
    }

    public class Demo4Input
    {
    }
}