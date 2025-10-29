using UnityEngine;

namespace Game
{
    public class VerticalScroller : MonoBehaviour
    {
        [SerializeField] private float _speed;
    
        private bool _scrolling;
        
        private void Update()
        {
            if (!_scrolling)
                return;
            
            float moveAmount = _speed * Time.deltaTime;
            Vector3 movement = moveAmount * Vector3.up;
        
            transform.Translate(movement);
        }
        
        public void SetScrollStatus(bool scroll) => _scrolling = scroll;
    }
}
