using System;
using System.Reflection;
using FubuCore.CommandLine;

namespace ZeroMQDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var commands = Bootstrap();
            var executor = new CommandExecutor(commands);
            var command = Help(executor);

            while (command != "exit")
            {
                executor.Execute(command);
                command = Help(executor);
            }
        }

        private static ICommandFactory Bootstrap()
        {
            var commands = new CommandFactory();
            commands.RegisterCommands(typeof(IFubuCommand).Assembly);
            commands.RegisterCommands(Assembly.GetExecutingAssembly());
            return commands;
        }

        private static string Help(CommandExecutor executor)
        {
            executor.Execute("help");
            var command = Console.ReadLine();
            return command;
        }
    }
}