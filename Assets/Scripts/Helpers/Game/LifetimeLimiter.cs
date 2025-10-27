using UnityEngine;
using UnityEngine.Events;

namespace Helpers.Game
{
    public class LifetimeLimiter : MonoBehaviour
    {
        [SerializeField] public UnityEvent<float> SecondTicked;
        
        [SerializeField] private float _lifetime;

        private float _timeLived;
        private float _secondTimer;

        private void Start()
        {
            SecondTicked?.Invoke(_lifetime);
        }
        
        private void Update()
        {
            _timeLived += Time.deltaTime;
            _secondTimer += Time.deltaTime;
            
            if (_timeLived > _lifetime)
                Destroy(gameObject);
            
            if (_secondTimer >= 1)
            {
                SecondTicked?.Invoke(_lifetime - _timeLived);
                _secondTimer = 0;
            }
        }
    }
}