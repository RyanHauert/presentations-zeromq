using System.Threading;
using FubuCore.CommandLine;

namespace ZeroMQDemo
{
    [CommandDescription("Demo 3: pipeline using PUSH and PULL sockets", Name = "demo3")]
    public class Demo3Command : FubuCommand<Demo3Input>
    {
        public override bool Execute(Demo3Input input)
        {
            Runner.Start("demo3 ventilator");
            Runner.Start("demo3 sink");
            Runner.Start("demo3 worker -w 1");
            Runner.Start("demo3 worker -w 2");
            Runner.Start("demo3 worker -w 3");

            return true;
        }
    }

    public class Demo3Input
    {
    }
}