using FubuCore.CommandLine;

namespace ZeroMQDemo
{
    [CommandDescription("Stops the current demo and closes any open console windows", Name = "reset")]
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