using UnityEngine;
using UnityEngine.Events;

namespace Actors
{
    public class Entity : MonoBehaviour
    {
        public UnityEvent<float> HealthChanged;
        public UnityEvent<GameObject> DiedFromDamage;
        public UnityEvent<GameObject> Destroyed;
    
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

            if (_currentHealth > 0)
                return;
            
            DiedFromDamage?.Invoke(gameObject);
            Destroyed?.Invoke(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(tag))
                return;
            
            if (!collision.gameObject.TryGetComponent(out Entity entity))
                return;
        
            entity.TakeDamage(_contactDamage);
        }
        
        private void OnDestroy()
        {
            Destroyed?.Invoke(gameObject);
        }
    }
}