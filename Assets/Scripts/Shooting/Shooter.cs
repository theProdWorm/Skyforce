using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Shooting
{
    public class Shooter : MonoBehaviour
    {
        private Weapon _weapon;

        private int _weaponCount;

        private bool _shooting;
        
        private void Start()
        {
            var child = transform.GetChild(0);
            var weapon = child.GetComponent<Weapon>();

            _weapon = weapon;
            _weapon.tag = tag;
        }
        
        private void Update()
        {
            var childCount = transform.childCount;
            
            if (_weaponCount == childCount)
                return;
            
            var targetWeaponTransform = transform.GetChild(childCount - 1);
            SwitchWeapon(targetWeaponTransform);
            
            _weaponCount = childCount;

            if (childCount <= 2)
                return;

            Destroy(transform.GetChild(1).gameObject);
        }

        private void SwitchWeapon(Transform child)
        {
            _weapon.SetShootingStatus(false);
            
            var weapon = child.GetComponent<Weapon>();
            _weapon = weapon;
            
            weapon.tag = tag;
            
            weapon.SetShootingStatus(_shooting);
        }

        public void SetShootingStatus(bool shooting)
        {
            _shooting = shooting;
            _weapon.SetShootingStatus(shooting);
        }
    }
}