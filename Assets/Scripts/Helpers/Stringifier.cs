using UnityEngine;
using UnityEngine.Events;

namespace Helpers
{
    public class Stringifier : MonoBehaviour
    {
        [SerializeField] public UnityEvent<string> StringProduced;
        
        [SerializeField] private string _format;
        
        public void ProduceString(float value) => StringProduced?.Invoke(value.ToString(_format));
    }
}