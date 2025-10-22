using UnityEngine;

public class VerticalScroller : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private void Update()
    {
        float moveAmount = _speed * Time.deltaTime;
        Vector3 movement = moveAmount * Vector3.up;
        
        transform.Translate(movement);
    }
}
