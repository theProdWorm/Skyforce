using System.Collections.Generic;
using UnityEngine;

namespace Shooting
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponStats _stats;
    
        [SerializeField] private bool _syncBarrels;

        private readonly List<Transform> _barrels = new();
        
        private bool _shooting;
        private float _timer;

        // Used only if barrels are not synced
        private int _barrelIndex;

        private void Start()
        {
            _barrels.AddRange(GetComponentsInChildren<Transform>());
        }
        
        private void Update()
        {
            if (_timer > 0)
                _timer -= Time.deltaTime;
            else if (_shooting)
            {
                _timer = 1 / _stats.ShotsPerSecond;

                if (_syncBarrels)
                {
                    foreach (var barrel in _barrels)
                        Shoot(barrel);
                }
                else
                {
                    var barrel = _barrels[_barrelIndex];
                    Shoot(barrel);
                    
                    _barrelIndex = (_barrelIndex + 1) % _barrels.Count;
                }
            }
        }
        
        private void Shoot(Transform barrel)
        {
            var bullet = Instantiate(_stats.BulletPrefab, barrel.position, Quaternion.identity);
        
            float maxDeviation = 0.01f * (100 - Mathf.Clamp(_stats.Accuracy, 0, 100));
            float deviation = 90f * Random.Range(-maxDeviation, maxDeviation);

            var velocity = Quaternion.AngleAxis(deviation, Vector3.forward) * barrel.up * _stats.BulletSpeed;
            
            bullet.Initialize(velocity, tag, _stats.Damage, _stats.Pierce);
        }

        public void SetShootingStatus(bool shooting) => _shooting = shooting;
    }
}