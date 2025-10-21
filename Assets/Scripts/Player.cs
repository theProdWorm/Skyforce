using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Player : Shooter
{
    [SerializeField] private Rigidbody2D _rigidbody;
    
    [SerializeField] private float _movementSpeed;

    public void OnMove(InputAction.CallbackContext context)
    {
        _rigidbody.linearVelocity = _movementSpeed * context.ReadValue<Vector2>();
    }
    
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.started)
            _shooting = true;
        else if (context.canceled)
            _shooting = false;
    }
}
