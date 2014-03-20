using System;
using System.Linq;
using System.Reflection;
using FubuCore;

namespace ZeroMQRunner
{
    class Program : ConsoleApp
    {
        static void Main(string[] args)
        {
            DefaultExecution(args);
            Console.ReadKey();
        }
    }

    public static class ReflectionHelper
    {
        public static T FindMatchingInstance<T>(Func<T, bool> predicate)
        {
            return Assembly.GetExecutingAssembly().DefinedTypes
                .Where(x => x.IsConcreteTypeOf<T>())
                .Select(Activator.CreateInstance)
                .Cast<T>()
                .Single(predicate);
        }
    }
}
