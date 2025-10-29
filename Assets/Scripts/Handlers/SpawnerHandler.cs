using System.Linq;
using Actors;
using Game;
using UnityEngine;
using UnityEngine.Events;

namespace Handlers
{
    public class SpawnerHandler : MonoBehaviour
    {
        [SerializeField] public UnityEvent<GameObject> EnemyDiedFromDamage;
        [SerializeField] public UnityEvent<GameObject> EnemyReachedEnd;
        [SerializeField] public UnityEvent<int>        EnemyCountCalculated;

        private void Start()
        {
            var flyingEnemyWaveSpawners = FindObjectsByType<FlyingEnemyWaveSpawner>(FindObjectsSortMode.None);

            foreach (var spawner in flyingEnemyWaveSpawners)
            {
                spawner.EnemySpawned.AddListener(OnEnemySpawned);
            }
        }

        private void OnEnemySpawned(Entity enemy)
        {
            enemy.DiedFromDamage.AddListener(EnemyDiedFromDamage.Invoke);

            var splineFollower = enemy.GetComponent<SplineFollower>();
            splineFollower.ReachedEnd.AddListener(EnemyReachedEnd.Invoke);
        }

        public void CalculateTotalEnemyCount()
        {
            var flyingEnemyWaveSpawners = FindObjectsByType<FlyingEnemyWaveSpawner>(FindObjectsSortMode.None);

            int totalCount = flyingEnemyWaveSpawners.Sum(spawner => spawner.GetEnemyCount());
            
            EnemyCountCalculated?.Invoke(totalCount);
        }
    }
}