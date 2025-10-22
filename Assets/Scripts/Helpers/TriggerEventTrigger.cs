using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Helpers
{
    public class TriggerEventTrigger : MonoBehaviour
    {
        [SerializeField] public UnityEvent<GameObject> TriggerEntered;
        [SerializeField] public UnityEvent<GameObject> TriggerExited;

        [Tooltip("If empty, all tags are allowed")]
        [SerializeField] private List<string> _allowedTags;

        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            if (_allowedTags.Count > 0 && !_allowedTags.Contains(otherCollider.gameObject.tag))
                return;
                
            TriggerEntered?.Invoke(otherCollider.gameObject);
        }

        private void OnTriggerExit2D(Collider2D otherCollider)
        {
            if (_allowedTags.Count > 0 && !_allowedTags.Contains(otherCollider.gameObject.tag))
                return;
            
            TriggerExited?.Invoke(otherCollider.gameObject);
        }
    }
}