namespace ZeroMQRunner.Demo3
{
    public interface IDemo3Endpoint
    {
        string Type { get; }
        void Execute(Demo3Input input);
    }
}