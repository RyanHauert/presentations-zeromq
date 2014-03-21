using FubuCore.CommandLine;

namespace ZeroMQDemo
{
    [CommandDescription("Resets for another demo", Name = "reset")]
    public class ResetCommand : FubuCommand<ResetInput>
    {
        public override bool Execute(ResetInput input)
        {
            Runner.Reset();
            return true;
        }
    }

    public class ResetInput
    {
    }
}