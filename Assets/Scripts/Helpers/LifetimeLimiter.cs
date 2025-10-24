using UnityEngine;

namespace Helpers
{
    public class LifetimeLimiter : MonoBehaviour
    {
        [SerializeField] private float _lifetime;

        private float _timeLived;
        
        private void Update()
        {
            _timeLived += Time.deltaTime;
            
            if (_timeLived > _lifetime)
                Destroy(gameObject);
        }
    }
}