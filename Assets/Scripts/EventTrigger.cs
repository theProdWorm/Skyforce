using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    public UnityEvent<GameObject> OnTriggerEnter;
    public UnityEvent<GameObject> OnTriggerExit;

    private void OnTriggerEnter2D(Collider2D otherCollider) =>
        OnTriggerEnter?.Invoke(otherCollider.gameObject);

    private void OnTriggerExit2D(Collider2D otherCollider) =>
        OnTriggerExit?.Invoke(otherCollider.gameObject);
}