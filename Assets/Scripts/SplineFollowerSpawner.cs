using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines;

public class SplineFollowerSpawner : MonoBehaviour
{
    public UnityEvent<SplineFollower> SplineFollowerSpawned;
    
    [SerializeField] private SplineContainer _path;
    [SerializeField] private List<SplineFollower> _objectsToSpawn;
    [SerializeField] private float _spawnDelay;

    private float _spawnTimer;

    private void Update()
    {
        if (_spawnTimer > 0)
            _spawnTimer -= Time.deltaTime;

        if (!(_spawnTimer <= 0))
            return;
        
        var obj = Instantiate(_objectsToSpawn[0], transform.position, Quaternion.identity);
        obj.Initialize(_path);
        
        _objectsToSpawn.RemoveAt(0);
        
        if (_objectsToSpawn.Count == 0)
            Destroy(this);
        
        _spawnTimer = _spawnDelay;
    }
}
