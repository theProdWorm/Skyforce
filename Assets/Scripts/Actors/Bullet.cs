using UnityEngine;

namespace Actors
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
    
        private float _damage;
        private bool _pierce;

        public void Initialize(Vector2 velocity, string allyTag, float damage, bool pierce)
        {
            _rigidbody.linearVelocity = velocity;
            transform.up = velocity.normalized;
        
            tag = allyTag;
        
            _damage = damage;
            _pierce = pierce;
        }
    
        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            if (otherCollider.gameObject.CompareTag(tag))
                return;
            
            if (!otherCollider.gameObject.TryGetComponent(out Entity entity))
                return;
        
            entity.TakeDamage(_damage);

            if (_pierce)
                return;
        
            Destroy(gameObject);
        }
    }
}