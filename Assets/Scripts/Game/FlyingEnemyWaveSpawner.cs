using System.Collections.Generic;
using System.Linq;
using Actors;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines;

namespace Game
{
    public class FlyingEnemyWaveSpawner : MonoBehaviour
    {
        [SerializeField] public UnityEvent<Entity> EnemySpawned;
    
        [SerializeField] private SplineContainer _path;
        [SerializeField] private List<SplineFollower> _objectsToSpawn;
        [SerializeField] private float _spawnDelay;

        private float _spawnTimer;
        private bool _spawning;

        private int _numEnemiesToSpawn;
        private int _numDestroyedEnemies;

        public void StartSpawning()
        {
            _spawning = true;
            
            _numEnemiesToSpawn = _objectsToSpawn.Count;
        }
        
        private void Update()
        {
            if (!_spawning)
                return;
            
            if (_spawnTimer > 0)
                _spawnTimer -= Time.deltaTime;

            if (_spawnTimer > 0)
                return;

            var splineFollower = Instantiate(_objectsToSpawn[0], transform.position, Quaternion.identity);
            splineFollower.Initialize(_path);

            var entity = splineFollower.GetComponent<Entity>();
            EnemySpawned?.Invoke(entity);
            entity.Destroyed.AddListener(e =>
            {
                _numDestroyedEnemies++;
                
                if (_numDestroyedEnemies == _numEnemiesToSpawn)
                    Destroy(gameObject);
            });
            
            _objectsToSpawn.RemoveAt(0);
            _spawnTimer = _spawnDelay;
            
            if (_objectsToSpawn.Count == 0)
                _spawning = false;
        }
    }
}
