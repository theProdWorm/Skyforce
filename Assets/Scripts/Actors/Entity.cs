using UnityEngine;
using UnityEngine.Events;

namespace Actors
{
    public class Entity : MonoBehaviour
    {
        public UnityEvent<float> DamageTaken;
        public UnityEvent<GameObject> DiedFromDamage;
        public UnityEvent<GameObject> Destroyed;
    
        [SerializeField] private float _maxHealth = 1f;

        [SerializeField] private float _contactDamage;
    
        private float _currentHealth;

        private bool _destroyed;

        private void Awake()
        {
            _currentHealth = _maxHealth;
            
            Destroyed.AddListener(_ => _destroyed = true);
        }

        public void TakeDamage(float damage)
        {
            if (damage <= 0)
                return;
            
            _currentHealth -= damage;
        
            DamageTaken?.Invoke(_currentHealth);

            if (_currentHealth > 0)
                return;
            
            DiedFromDamage?.Invoke(gameObject);
            Destroyed?.Invoke(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_destroyed || collision.gameObject.CompareTag(tag))
                return;
            
            if (!collision.gameObject.TryGetComponent(out Entity entity))
                return;
        
            entity.TakeDamage(_contactDamage);
        }
        
        private void OnDestroy()
        {
            if (!_destroyed)
                Destroyed?.Invoke(gameObject);
        }
    }
}