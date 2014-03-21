using FubuCore.CommandLine;

namespace ZeroMQRunner.Demo2
{
    [CommandDescription("Runs the second demo", Name = "demo2")]
    public class Demo2Command : FubuCommand<Demo2Input>
    {
        public override bool Execute(Demo2Input input)
        {
            var endpoint = ReflectionHelper.FindMatchingInstance<IDemo2Endpoint>(x => x.Type == input.Type);
            endpoint.Execute(input);
            return true;
        }
    }
}