using System.Collections.Generic;

namespace Common.SynchronisedGameObject.Interfaces
{
    public static class LogicObjectManager
    {
        private static ILogicObjectManager _instance;

        public static ILogicObjectManager Instance
        {
            get
            {
                return _instance;
            }
        }
        public static void SetInstance(ILogicObjectManager instance)
        {
            _instance = instance;
        }

        public static Dictionary<int, IGameEntity> GameObjects => Instance.GameObjects;
        public static int Register(IGameEntity entity) => Instance.Register(entity);
        public static void Deregister(int id) => Instance.Deregister(id);
    }
}
