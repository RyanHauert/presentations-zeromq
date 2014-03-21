﻿using System;
using System.Text;
using fszmq;

namespace ZeroMQRunner.Demo1
{
    public class Server : Endpoint, IDemo1Endpoint
    {
        public void Execute()
        {
            using (var context = new Context())
            using (var responder = context.Response())
            {
                responder.Bind("tcp://*:5555");
                HandleRequests(responder);
            }
        }

        private static void HandleRequests(Socket responder)
        {
            while (true)
            {
                byte[] request = responder.Recv();
                string message = Encoding.Unicode.GetString(request);
                Console.WriteLine("Received: {0}", message);

                responder.Send(Encoding.Unicode.GetBytes("World"));
            }
        }

        public void PositionWindow()
        {
            ConsoleApp.MoveWindow(100, 100);
        }
    }
}