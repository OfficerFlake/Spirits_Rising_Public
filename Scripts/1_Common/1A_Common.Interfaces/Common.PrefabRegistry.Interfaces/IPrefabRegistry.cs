using System;
using UnityEngine;

namespace Common.PrefabRegistry.Interfaces
{
    public interface IPrefabRegistry
    {
        GameObject GetPrefab(Enum key);
    }
}
