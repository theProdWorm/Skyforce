using UnityEngine;

namespace Helpers
{
    public class SpriteManipulator : MonoBehaviour
    {
        [SerializeField] private Color _redTint = Color.red;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private float _remainingDuration;
    
        private void Update()
        {
            if (_remainingDuration > 0)
                _remainingDuration -= Time.deltaTime;
            if (_remainingDuration <= 0)
                _spriteRenderer.color = Color.white;
        }
    
        public void TintRed(float duration)
        {
            _spriteRenderer.color = _redTint;
        
            _remainingDuration = duration;
        }
    }
}
