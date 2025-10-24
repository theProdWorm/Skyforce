using UnityEngine;

namespace Game.Loot
{
    public class LootDropper : MonoBehaviour
    {
        [SerializeField] private Transform _stage;
        [SerializeField] private LootTable _lootTable;
        
        public void DropLoot(GameObject source)
        {
            GameObject drop = _lootTable.Loot();

            if (drop == null)
                return;
            
            Instantiate(drop, source.transform.position, Quaternion.identity, _stage);
        }
    }
}
