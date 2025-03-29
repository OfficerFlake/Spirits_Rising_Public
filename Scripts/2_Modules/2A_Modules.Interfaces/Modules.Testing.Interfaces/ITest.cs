using System;

namespace Modules.Testing.Interfaces
{
    public interface ITest : IDisposable
    {
        Action Init { get; }
        Action Run { get; }
    }
}