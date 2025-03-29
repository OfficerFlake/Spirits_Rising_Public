using System.Collections.Generic;

namespace Common.SynchronisedGameObject.Interfaces
{
    public interface ILogicObjectManager
    {
        Dictionary<int, IGameEntity> GameObjects { get; }
        int Register(IGameEntity entity);
        void Deregister(int id);
    }
}
