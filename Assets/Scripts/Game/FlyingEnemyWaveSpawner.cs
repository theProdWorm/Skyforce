using System.Collections.Generic;
using Actors;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines;

namespace Game
{
    public class FlyingEnemyWaveSpawner : MonoBehaviour
    {
        [SerializeField] public UnityEvent<GameObject> EnemySpawned;
        [SerializeField] public UnityEvent<GameObject> EnemyDied;
    
        [SerializeField] private SplineContainer _path;
        [SerializeField] private List<SplineFollower> _objectsToSpawn;
        [SerializeField] private float _spawnDelay;

        private float _spawnTimer;
        private bool _spawning;
        
        private readonly List<GameObject> _aliveEnemies = new();

        public void StartSpawning()
        {
            _spawning = true;
        }
        
        private void Update()
        {
            if (!_spawning)
                return;
            
            if (_spawnTimer > 0)
                _spawnTimer -= Time.deltaTime;

            if (!(_spawnTimer <= 0))
                return;

            var splineFollower = Instantiate(_objectsToSpawn[0], transform.position, Quaternion.identity);
            splineFollower.Initialize(_path);

            var entity = splineFollower.GetComponent<Entity>();
            entity.Died.AddListener(e =>
            {
                EnemyDied.Invoke(e);
                _aliveEnemies.Remove(e);
                
                print(e.name + " died");
                
                if (_objectsToSpawn.Count == 0 && _aliveEnemies.Count == 0)
                    Destroy(gameObject);
            });

            _aliveEnemies.Add(entity.gameObject);
            EnemySpawned?.Invoke(entity.gameObject);

            _objectsToSpawn.RemoveAt(0);
            _spawnTimer = _spawnDelay;
            
            if (_objectsToSpawn.Count == 0)
                _spawning = false;
        }
    }
}
