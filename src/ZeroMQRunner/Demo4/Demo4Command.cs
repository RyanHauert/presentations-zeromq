using FubuCore.CommandLine;

namespace ZeroMQRunner.Demo4
{
    [CommandDescription("Runs the fourth demo", Name = "demo4")]
    public class Demo4Command : FubuCommand<Demo4Input>
    {
        public override bool Execute(Demo4Input input)
        {
            var endpoint = ReflectionHelper.FindMatchingInstance<IDemo4Endpoint>(x => x.Type == input.Type);
            endpoint.PositionWindow(input);
            endpoint.Execute(input);
            return true;
        }
    }
}