using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineFollower : MonoBehaviour
{
    [SerializeField] private SplineContainer _path;

    [SerializeField] private float _speed;

    private float _timeToReach;
    private float _elapsedTime;

    public void Initialize(SplineContainer path)
    {
        _path = path;
    }
    
    private void Start()
    {
        float pathLength = _path.CalculateLength();
        
        _timeToReach = pathLength / _speed;
    }
    
    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        
        float t = Mathf.Clamp01(_elapsedTime / _timeToReach);
        transform.localPosition = _path.EvaluatePosition(t);
        transform.right = -_path.EvaluateTangent(t);
    }
}