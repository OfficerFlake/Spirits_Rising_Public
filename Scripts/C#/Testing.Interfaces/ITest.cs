using System;

namespace Testing.Interfaces
{
    public interface ITest : IDisposable
    {
        void Init();
        void Run();
    }
}