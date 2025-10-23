using UnityEngine;

namespace Handlers
{
    public class ParticleSystemKiller : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;

        private bool _listenerSet;
        
        private void Update()
        {
            if (_listenerSet)
                return;

            if (!_particleSystem.isPlaying) 
                return;
            
            float delay = _particleSystem.main.duration + _particleSystem.main.startLifetime.constantMax;
            
            Destroy(_particleSystem.gameObject, delay);
            _listenerSet = true;
        }
    }
}
