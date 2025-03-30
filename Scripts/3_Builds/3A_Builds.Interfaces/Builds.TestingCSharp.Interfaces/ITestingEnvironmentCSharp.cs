using System;

namespace Builds.TestingCSharp.Interfaces
{
    public interface IBuildTestingEnvironmentCSharp
    {
        Action Initialize { get; }
        Action Run { get; }
        Action Stop { get; }
    }
}
