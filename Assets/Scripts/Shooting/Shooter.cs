using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Shooting
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _weapons;

        private void Start()
        {
            _weapons.ForEach(weapon => weapon.tag = tag);
        }
        
        public void AddWeapon(Weapon weapon)
        {
            _weapons.Add(weapon);
            weapon.tag = tag;
        }

        public void RemoveWeapon(Weapon weapon)
        {
            if (!_weapons.Contains(weapon))
                return;
            
            _weapons.Remove(weapon);
            weapon.tag = "Untagged";
        }

        public void SetShootingStatus(bool shooting) =>
            _weapons.ForEach(weapon => weapon.SetShootingStatus(shooting));
    }
}