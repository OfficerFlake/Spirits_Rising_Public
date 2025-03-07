using System.Threading.Tasks;

namespace Builds.TestingCSharp.Interfaces
{
    public interface ITestingEnvironmentCSharp
    {
        Task Initialize();
        Task Start();
        Task Stop();
    }
}
