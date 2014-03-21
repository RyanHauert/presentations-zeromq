namespace ZeroMQRunner.Demo2
{
    public interface IDemo2Endpoint
    {
        string Type { get; }
        void Execute(Demo2Input input);
        void PositionWindow(Demo2Input input);
    }
}