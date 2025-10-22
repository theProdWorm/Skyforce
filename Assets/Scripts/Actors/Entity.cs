using UnityEngine;
using UnityEngine.Events;

namespace Actors
{
    public class Entity : MonoBehaviour
    {
        public UnityEvent<float> HealthChanged;
        public UnityEvent<Entity> Died;
    
        [SerializeField] private float _maxHealth = 1f;

        [SerializeField] private float _contactDamage;
    
        private float _currentHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
        
            HealthChanged?.Invoke(_currentHealth);
        
            if (_currentHealth <= 0)
                Died?.Invoke(this);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.TryGetComponent(out Entity entity))
                return;
        
            entity.TakeDamage(_contactDamage);
        }
    }
}