using FubuCore.CommandLine;

namespace ZeroMQDemo
{
    [CommandDescription("Demo 1: simple request/reply server and client", Name = "demo1")]
    public class Demo1Command : FubuCommand<Demo1Input>
    {
        public override bool Execute(Demo1Input input)
        {
            Server.Start("demo1");
            Client.Start("demo1");
            return true;
        }
    }

    public class Demo1Input
    {
    }
}