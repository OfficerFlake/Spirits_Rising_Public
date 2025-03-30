using Common.ThreadSafeStream.Implementation;
using Common.ThreadSafeStream.Interfaces;
using System;

namespace Modules.Console.Interfaces
{
    public interface IConsole
    {
        IThreadSafeStream<string> Messages { get; }
        IThreadSafeStream<bool> Show { get; }
    };
    public static class Console
    {
        private static IConsole _instance;
        public static IConsole Instance => _instance;
        public static void SetInstance(IConsole console) => _instance = console;
        public static void Write(string Message) => Instance?.Messages?.Down?.Add(Message);
        public static void WriteLine(string Message) => Write("\n" + Message);

        public static void Show() => Instance?.Show?.Down?.Add(true);
        public static void Hide() => Instance?.Show?.Down?.Add(false);
    }
}
