using Common.ThreadSafeStream.Implementation;
using Common.ThreadSafeStream.Interfaces;
using System;

namespace Modules.Console.Interfaces
{
    public interface IConsoleLogic
    {
        IThreadSafeStreamWrapperLogic<string> Messages { get; }
        IThreadSafeStreamWrapperLogic<bool> Show { get; }
    };

    public interface IConsoleUnity
    {
        IThreadSafeStreamWrapperUnity<string> Messages { get; }
        IThreadSafeStreamWrapperUnity<bool> Show { get; }
    };
    public static class Console
    {
        private static IConsoleLogic _instance;
        public static IConsoleLogic Instance => _instance;
        public static void SetInstance(IConsoleLogic console) => _instance = console;
        public static void Write(string Message) => Instance.Messages.Value = Message;
        public static void WriteLine(string Message) => Write("\n" + Message);

        public static void Show() => Instance.Show.Value = true;
        public static void Hide() => Instance.Show.Value = false;
    }
}
