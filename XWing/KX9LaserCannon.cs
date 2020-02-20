using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace XWing
{
    public class KX9LaserCannon : IWeapon
    {
        private readonly int _weaponId;
        private bool IsArmed = false;
        public KX9LaserCannon(int weaponId)
        {
            _weaponId = weaponId;
        }
        public void ArmWeapon()
        {
            IsArmed = true;
            Console.WriteLine($"Arming weapon {this.GetType().ToString()} {_weaponId}");
        }

        public void DisarmWeapon()
        {
            IsArmed = false;
            Console.WriteLine($"Disarming weapon {this.GetType().ToString()} {_weaponId}");
        }

        public void FireWeapon()
        {
            Console.WriteLine($"Firing weapon {this.GetType().ToString()} {_weaponId}");
        }

        public int GetRemainingAmmo()
        {
            Console.WriteLine($"{this.GetType().ToString()}'s don't require ammo");
            return -1;
        }

        public int GetWeaponId()
        {
            return _weaponId;
        }

        public void LoadWeapon(int amountOfAmmunition)
        {
            Console.WriteLine($"{this.GetType().ToString()}'s don't require ammo");
        }
    }
}
