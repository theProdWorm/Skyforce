using UnityEngine;

namespace Game.Loot
{
    [System.Serializable]
    public class LootItem
    {
        [SerializeField] public GameObject Prefab;
        [SerializeField] public int Weight;
    }
}