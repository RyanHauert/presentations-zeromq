namespace ZeroMQRunner.Demo1
{
    public interface IDemo1Endpoint
    {
        string Type { get; }
        void Execute();
        void PositionWindow();
    }
}