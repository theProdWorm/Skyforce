using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour
{
    public UnityEvent<float> OnHealthChanged;
    public UnityEvent<Entity> OnDeath;
    
    [SerializeField] private float _maxHealth = 1f;
    
    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        
        OnHealthChanged?.Invoke(_currentHealth);
        
        if (_currentHealth <= 0)
            OnDeath?.Invoke(this);
    }
}