using FubuCore.CommandLine;

namespace ZeroMQDemo
{
    [CommandDescription("Demo 2: pub/sub server and clients", Name = "demo2")]
    public class Demo2Command : FubuCommand<Demo2Input>
    {
        public override bool Execute(Demo2Input input)
        {
            Server.Start("demo2");
            Client.Start("demo2");
            return true;
        }
    }

    public class Demo2Input
    {
    }
}