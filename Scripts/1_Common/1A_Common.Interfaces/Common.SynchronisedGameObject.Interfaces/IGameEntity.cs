 namespace Common.SynchronisedGameObject.Interfaces
{
    /// <summary>
    /// A common tag for any game object that exists in the Logic space that needs to also be represented in the Unity space.
    /// </summary>
    public interface IGameEntity
    {
        public System.Enum EnumType { get; }
    }

}

