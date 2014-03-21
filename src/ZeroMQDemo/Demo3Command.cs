using FubuCore;
using FubuCore.CommandLine;

namespace ZeroMQDemo
{
    [CommandDescription("Demo 3: pipeline using PUSH and PULL sockets", Name = "demo3")]
    public class Demo3Command : FubuCommand<Demo3Input>
    {
        public override bool Execute(Demo3Input input)
        {
            Runner.Start("demo3 sink");

            int workerCount = int.Parse(input.WorkerCountFlag ?? "3");
            for (int i = 0; i < workerCount; i++)
            {
                Runner.Start("demo3 worker -w {0}".ToFormat(i + 1));
            }
            //Runner.Start("demo3 worker -w 1");
            //Runner.Start("demo3 worker -w 2");
            //Runner.Start("demo3 worker -w 3");
            Runner.Start("demo3 ventilator");

            return true;
        }
    }

    public class Demo3Input
    {
        public string WorkerCountFlag { get; set; }
    }
}