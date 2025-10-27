using UnityEngine;
using UnityEngine.Events;

namespace Helpers.Interpreters
{
    public class ObjectCounter : MonoBehaviour
    {
        [SerializeField] public UnityEvent<int> Calculated;
        
        [SerializeField] private string _tag;
        
        public void Calculate()
        {
            int count = GameObject.FindGameObjectsWithTag(_tag).Length;
            
            Calculated?.Invoke(count);
        }
    }
}