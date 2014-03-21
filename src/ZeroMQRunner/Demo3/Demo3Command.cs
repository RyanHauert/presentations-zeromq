using FubuCore.CommandLine;

namespace ZeroMQRunner.Demo3
{
    [CommandDescription("Runs the third demo", Name = "demo3")]
    public class Demo3Command : FubuCommand<Demo3Input>
    {
        public override bool Execute(Demo3Input input)
        {
            var endpoint = ReflectionHelper.FindMatchingInstance<IDemo3Endpoint>(x => x.Type == input.Type);
            endpoint.Execute(input);
            return true;
        }
    }
}