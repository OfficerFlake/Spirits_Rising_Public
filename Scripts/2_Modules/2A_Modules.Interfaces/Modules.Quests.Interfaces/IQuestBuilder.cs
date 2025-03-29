namespace Modules.Quests.Interfaces
{
    public interface IQuestBuilder
    {
        IQuestBuilder AddStep(IStep step);   // Add a step to the quest
        IQuestBuilder Entry(IStep step);     // Set the entry step
        IQuestBuilder Exit(IStep step);      // Set the exit step
        IQuest Build();                      // Build the final quest object
    }
}