using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Helpers.Events
{
    public class TriggerEventTrigger : MonoBehaviour
    {
        [SerializeField] public UnityEvent<GameObject> TriggerEntered;
        [SerializeField] public UnityEvent<GameObject> TriggerExited;
        
        [SerializeField] private bool _destroySelfOnEnter;
        [SerializeField] private bool _destroySelfOnExit;

        [Tooltip("If empty, all tags are allowed")]
        [SerializeField] private List<string> _allowedTags;

        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            if (_allowedTags.Count > 0 && !_allowedTags.Contains(otherCollider.gameObject.tag))
                return;
                
            TriggerEntered?.Invoke(otherCollider.gameObject);
            
            if (_destroySelfOnEnter)
                Destroy(gameObject);
        }

        private void OnTriggerExit2D(Collider2D otherCollider)
        {
            if (_allowedTags.Count > 0 && !_allowedTags.Contains(otherCollider.gameObject.tag))
                return;
            
            TriggerExited?.Invoke(otherCollider.gameObject);
            
            if (_destroySelfOnExit)
                Destroy(gameObject);
        }
    }
}