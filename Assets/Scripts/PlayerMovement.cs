using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    
    [SerializeField] private float _movementSpeed;

    public void OnMove(InputAction.CallbackContext context)
    {
        _rigidbody.linearVelocity = _movementSpeed * context.ReadValue<Vector2>();
    }
}
