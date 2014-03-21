namespace ZeroMQRunner.Demo4
{
    public interface IDemo4Endpoint
    {
        string Type { get; }
        void Execute(Demo4Input input);
        void PositionWindow(Demo4Input input);
    }
}