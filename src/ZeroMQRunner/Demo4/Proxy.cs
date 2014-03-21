using fszmq;

namespace ZeroMQRunner.Demo4
{
    public class Proxy : Endpoint, IDemo4Endpoint
    {
        public void Execute(Demo4Input input)
        {
            using (var context = new Context())
            using (var frontend = context.Router())
            using (var backend = context.Dealer())
            {
                frontend.Bind("tcp://*:5559");
                backend.Bind("tcp://*:5560");

                frontend.Proxy(backend);
            }
        }

        public void PositionWindow(Demo4Input input)
        {
            ConsoleApp.MoveWindow(400, 300);
        }
    }
}