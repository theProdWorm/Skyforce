using UnityEngine;
using UnityEngine.Events;

namespace Helpers
{
    public class Instantiator : MonoBehaviour
    {
        [SerializeField] public UnityEvent<GameObject> Instantiated;
        
        [SerializeField] private GameObject _prefab;
        [SerializeField] private string     _parentName;
        
        public void Instantiate()
        {
            var parent = GameObject.Find(_parentName).transform;
            
            var instance = Instantiate(_prefab, parent);
            Instantiated?.Invoke(instance);
        }
    }
}