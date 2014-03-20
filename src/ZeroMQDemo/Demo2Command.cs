using FubuCore.CommandLine;

namespace ZeroMQDemo
{
    [CommandDescription("Demo 2: pub/sub server and clients", Name = "demo2")]
    public class Demo2Command : FubuCommand<Demo2Input>
    {
        public override bool Execute(Demo2Input input)
        {
            Runner.Start("demo2 server");
            Runner.Start("demo2 client -c 1 -z 84101");
            Runner.Start("demo2 client -c 2 -z 0");
            return true;
        }
    }

    public class Demo2Input
    {
    }
}