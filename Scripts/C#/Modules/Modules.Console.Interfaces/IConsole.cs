using System;

namespace Modules.Console.Interfaces
{
    public interface IConsole
    {
        void Write(string Message);
        void WriteLine(string Message);
    };
    public static class ConsoleManager
    {
        private static IConsole _instance;
        public static IConsole Instance {
            get { return _instance; }
            set { _instance = value; }
        }
        public static void Initialize(IConsole console)
        {
            _instance = console;
        }
    }
}
