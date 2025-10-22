using UnityEngine;
using UnityEngine.InputSystem;

namespace Actors
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
    
        [SerializeField] private float _movementSpeed;

        public void OnMove(InputAction.CallbackContext context)
        {
            _rigidbody.linearVelocity = _movementSpeed * context.ReadValue<Vector2>();
        }
    }
}
