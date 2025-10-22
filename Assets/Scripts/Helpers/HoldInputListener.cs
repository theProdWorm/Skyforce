using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Helpers
{
    public class HoldInputListener : MonoBehaviour
    {
        public UnityEvent InputStarted;
        public UnityEvent InputEnded;
    
        public void OnInput(InputAction.CallbackContext context)
        {
            if (context.started)
                InputStarted?.Invoke();
            else if (context.canceled)
                InputEnded?.Invoke();
        }
    }
}