using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace XWing
{
    public class KrupxMG7ProtonLauncher : IWeapon
    {
        private int RemainingAmmo = 0;
        private readonly int _weaponId;
        private bool IsArmed = false;
        public KrupxMG7ProtonLauncher(int weaponId)
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
            if (GetRemainingAmmo() <= 0)
                Console.WriteLine("Not enough ammunition to fire weapon");
            else if (!IsArmed)
                Console.WriteLine("Must arm weapon before firing");
            else
            {
                RemainingAmmo--;
                Console.WriteLine($"Firing {this.GetType().ToString()} {GetWeaponId()}");
            }
        }

        public int GetRemainingAmmo()
        {
            return RemainingAmmo;
        }

        public int GetWeaponId()
        {
            return _weaponId;
        }

        public void LoadWeapon(int amountOfAmmunition)
        {
            if (amountOfAmmunition <= 0)
                Console.WriteLine("Ammount of ammunition must be greater than 0");
            else
            {
                Console.WriteLine($"Loading {this.GetType().ToString()} {GetWeaponId()}");
                RemainingAmmo += amountOfAmmunition;
            }
        }
    }
}
