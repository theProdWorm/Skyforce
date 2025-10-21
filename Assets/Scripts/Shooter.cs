using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    
    [SerializeField] private float _shotsPerSecond;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private bool _piercingBullets;
    
    protected bool _shooting;

    private float _timer;
    
    private void Update()
    {
        if (_timer > 0)
            _timer -= Time.deltaTime;
        else if (_shooting)
            Shoot();
    }
    
    private void Shoot()
    {
        _timer = 1 / _shotsPerSecond;
        
        var bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        
        Vector2 velocity = transform.forward * _bulletSpeed;
        bullet.Initialize(velocity, tag, _damage, _piercingBullets);
    }
}