using System;
using UnityEngine;

namespace Common.PrefabRegistry.Interfaces
{
    public static class PrefabRegistry
    {
        private static IPrefabRegistry _instance;
        public static IPrefabRegistry Instance => _instance;
        public static void SetInstance(IPrefabRegistry instance) => _instance = instance;

        public static GameObject GetPrefab(Enum key) => Instance.GetPrefab(key);
    }
}
