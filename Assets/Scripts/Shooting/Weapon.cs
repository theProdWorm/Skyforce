using UnityEngine;

namespace Shooting
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponStats _stats;
    
        private bool _shooting;
        private float _timer;
        
        private void Update()
        {
            if (_timer > 0)
                _timer -= Time.deltaTime;
            else if (_shooting)
            {
                _timer = 1 / _stats.ShotsPerSecond;
                OnShot();
            }
        }
        
        public void OnShot()
        {
            var bullet = Instantiate(_stats.BulletPrefab, transform.position, Quaternion.identity);
        
            float maxDeviation = 0.01f * (100 - Mathf.Clamp(_stats.Accuracy, 0, 100));
            float deviation = 90f * Random.Range(-maxDeviation, maxDeviation);

            var velocity = Quaternion.AngleAxis(deviation, Vector3.forward) * transform.up * _stats.BulletSpeed;
            
            bullet.Initialize(velocity, tag, _stats.Damage, _stats.Pierce);
        }

        public void SetShootingStatus(bool shooting) => _shooting = shooting;
    }
}