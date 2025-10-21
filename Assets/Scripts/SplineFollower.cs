using UnityEngine;
using UnityEngine.Splines;

public class SplineFollower : MonoBehaviour
{
    [SerializeField] private SplineContainer _path;

    [SerializeField] private float _speed;

    private float _timeToReach;
    private float _elapsedTime;
    
    private void Start()
    {
        float pathLength = _path.CalculateLength();
        
        _timeToReach = pathLength / _speed;
    }
    
    private void Update()
    {
        float t = _elapsedTime / _timeToReach;
        transform.localPosition = _path.EvaluatePosition(t);
    }
}