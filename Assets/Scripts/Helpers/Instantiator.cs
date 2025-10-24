using UnityEngine;

namespace Helpers
{
    public class Instantiator : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private string     _parentName;
        
        public void Instantiate()
        {
            var parent = GameObject.Find(_parentName).transform;
            
            Instantiate(_prefab, parent);
        }
    }
}