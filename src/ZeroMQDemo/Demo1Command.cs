using FubuCore.CommandLine;

namespace ZeroMQDemo
{
    [CommandDescription("Demo 1: simple request/reply server and client", Name = "demo1")]
    public class Demo1Command : FubuCommand<Demo1Input>
    {
        public override bool Execute(Demo1Input input)
        {
            Runner.Start("demo1 server");
            Runner.Start("demo1 client");
            return true;
        }
    }

    public class Demo1Input
    {
    }
}