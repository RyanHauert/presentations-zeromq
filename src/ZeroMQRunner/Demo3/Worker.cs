using System;
using System.Text;
using System.Threading;
using fszmq;

namespace ZeroMQRunner.Demo3
{
    public class Worker : Endpoint, IDemo3Endpoint
    {
        public void Execute(Demo3Input input)
        {
            using (var context = new Context())
            using (var consumer = context.Pull())
            using (var reporter = context.Push())
            {
                consumer.Connect("tcp://localhost:5557");
                reporter.Connect("tcp://localhost:5558");

                DoWork(consumer, reporter, input.WorkerNumberFlag);
            }
        }

        private void DoWork(Socket consumer, Socket reporter, string workerId)
        {
            while (true)
            {
                var message = consumer.Recv();
                ProcessWorkItem(message);

                // Signal that we've finished the workitem.
                reporter.Send(Encoding.Unicode.GetBytes(workerId));
            }
        }

        private void ProcessWorkItem(byte[] message)
        {
            int sleepTime = BitConverter.ToInt32(message, 0);
            Console.WriteLine("Received work: {0} ms", sleepTime);
            Thread.Sleep(sleepTime);
        }

        public void PositionWindow(Demo3Input input)
        {
            Console.SetWindowSize(45, 15);
            Console.SetBufferSize(45, 15);

            int workerNumber = int.Parse(input.WorkerNumberFlag);
            ConsoleApp.MoveWindow(400 + (100 * (workerNumber - 1)), 100 + (75 * (workerNumber - 1)));
        }
    }
}