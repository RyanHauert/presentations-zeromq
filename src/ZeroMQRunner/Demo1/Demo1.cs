using FubuCore.CommandLine;

namespace ZeroMQRunner.Demo1
{
    [CommandDescription("Runs the first demo", Name = "demo1")]
    public class Demo1 : FubuCommand<Demo1Input>
    {
        public override bool Execute(Demo1Input input)
        {
            var endpoint = ReflectionHelper.FindMatchingInstance<IDemo1Endpoint>(x => x.Type == input.Type);
            endpoint.Execute();
            return true;
        }
    }

    public class Demo1Input
    {
        public string Type { get; set; }
    }
}