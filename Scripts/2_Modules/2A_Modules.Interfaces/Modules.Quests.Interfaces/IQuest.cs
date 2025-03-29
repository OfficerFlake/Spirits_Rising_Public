using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modules.Quests.Interfaces
{
    public interface IQuest
    {
        List<IStep> Steps { get; }        // List of steps in the quest
        IStep EntryStep { get; set; }     // The entry point for the quest
        IStep ExitStep { get; set; }      // The exit point for the quest

        void AddStep(IStep step);         // Add a step to the quest
        void GoToStep(IStep step);        // Move to the next or previous step
        Task StartQuest();                // Start the quest by checking conditions
    }
}