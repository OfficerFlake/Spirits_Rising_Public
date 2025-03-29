using Common.ThreadSafeStream.Implementation;
using System;

namespace Modules.Console.Interfaces
{
    public interface IConsole
    {
        void Write(string Message);
        void WriteLine(string Message);

        ThreadSafeStream<string> Messages { get; }
    };
    public static class Console
    {
        private static IConsole _instance;
        public static IConsole Instance => _instance;
        public static void SetInstance(IConsole console) => _instance = console;
        public static void Write(string Message) => Instance?.Write(Message);
        public static void WriteLine(string Message) => Instance?.WriteLine(Message);
    }
}
