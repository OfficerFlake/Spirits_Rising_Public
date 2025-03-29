using System.Threading.Tasks;

namespace Modules.Quests.Interfaces
{
    public interface IStep
    {
        Task SuccessCondition();    // Check the success condition (returns a Task)
        Task FailCondition();       // Check the fail condition (returns a Task)
        Task SuccessAction();       // Action to perform on success (returns a Task)
        Task FailAction();          // Action to perform on failure (returns a Task)

        IStep NextStep { get; }     // Define the next step
        IStep PreviousStep { get; } // Define the previous step

        Task CheckConditions();     // Check both success and fail conditions
    }
}