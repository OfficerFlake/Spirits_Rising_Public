using System.Threading.Tasks;

namespace Builds.TestingCSharp.Interfaces
{
    public interface ITestingEnvironmentCSharp
    {
        Task Initialize();
        Task Run();
        Task Stop();
    }
}
