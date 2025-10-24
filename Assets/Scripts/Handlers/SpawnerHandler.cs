using System.Collections.Generic;
using Actors;
using Game;
using UnityEngine;
using UnityEngine.Events;

namespace Handlers
{
    public class SpawnerHandler : MonoBehaviour
    {
        [SerializeField] public UnityEvent<GameObject> EnemyDiedFromDamage;

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
        }
    }
}