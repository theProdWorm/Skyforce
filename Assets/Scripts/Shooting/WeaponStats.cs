using Actors;
using UnityEngine;

namespace Shooting
{
    [CreateAssetMenu(menuName = "Shooting/Weapon Stats")]
    public class WeaponStats : ScriptableObject
    {
        [SerializeField] public Bullet BulletPrefab;

        [SerializeField] public float  ShotsPerSecond;
        [SerializeField] public float  BulletSpeed;
        [SerializeField] public float  Accuracy;
        [SerializeField] public float  Damage;
        [SerializeField] public bool   Pierce;
    }
}