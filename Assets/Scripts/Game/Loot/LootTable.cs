using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Loot
{
    [CreateAssetMenu(menuName = "Loot/Loot Table")]
    public class LootTable : ScriptableObject
    {
        [SerializeField] private List<LootItem> _lootItems;
        
        public GameObject Loot()
        {
            int totalWeight = _lootItems.Sum(lootItem => lootItem.Weight);
            
            int randomWeight = Random.Range(0, totalWeight);
            int currentWeight = 0;

            foreach (var lootItem in _lootItems)
            {
                currentWeight += lootItem.Weight;
                if (randomWeight < currentWeight)
                    return lootItem.Prefab;
            }

            return _lootItems[0].Prefab;
        }
    }
}