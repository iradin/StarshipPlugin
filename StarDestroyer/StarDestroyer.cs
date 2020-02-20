using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Interfaces;

namespace StarDestroyer
{
    public class StarDestroyer : IShip
    {
        private readonly IEngine _engine;
        private readonly IWeapon[] _weapons;
        private IShipState _shipState;
        public StarDestroyer(IEngine engine, IWeaponFactory ionCannonFactory, IShipState shipState)
        {
            _engine = engine;
            var ionCannons = new List<IWeapon>();
            for(var i = 0; i < 5; ++i)
            {
                ionCannons.Add(ionCannonFactory.Create());
            }
            _weapons = ionCannons.ToArray();
            _shipState = shipState;
        }
        public string GetShipType()
        {
            return "Imperial star destroyer";
        }
        public IWeapon[] GetWeapons()
        {
            return _weapons;
        }
        public void ArmWeapon(int weaponId)
        {
            if (weaponId >= 0 && weaponId < _weapons.Length)
                _weapons[weaponId].ArmWeapon();
        }

        public void LoadWeapon(int weaponId, int ammountOfAmmo)
        {
            if (weaponId >= 0 && weaponId < _weapons.Length)
                _weapons[weaponId].LoadWeapon(ammountOfAmmo);
        }

        public void DisarmWeapon(int weaponId)
        {
            if (weaponId >= 0 && weaponId < _weapons.Length)
                _weapons[weaponId].DisarmWeapon();
        }
        public void FireWeapon(int weaponId)
        {
            var weaponToFire = _weapons.FirstOrDefault(w => w.GetWeaponId() == weaponId);
            if (weaponToFire == null)
                Console.WriteLine($"No weapon of ID: {weaponId} found.");
            else
                weaponToFire.FireWeapon();
        }
        public void SetSpeed(int kps)
        {
            if (kps > _engine.GetMaxSpeed())
                Console.WriteLine($"Invalid speed of {kps} engine cannot exceed {_engine.GetMaxSpeed()}");
            else
                _engine.SetSpeed(kps);
        }
        public double GetSpeed()
        {
            return _shipState.CurrentSpeed;
        }
        public void ReadyWarpDrive()
        {
            _engine.SpoolWarpDrive();
        }
        public void WarpToLocation(double galacticLongitude, double galacticLatitude)
        {
            if (!_engine.IsWarpDriveEnabled())
                Console.WriteLine("Warp drive not enabled. Unable to perform warp operation.");
            else
            {
                var result = _engine.Warp();
                if (result >= 0)
                {
                    Console.WriteLine("Warping to location...");
                    Thread.Sleep(3000);
                    _shipState.CurrentLongitude = galacticLongitude;
                    _shipState.CurrentLatitude = galacticLatitude;
                    Console.WriteLine("Arrived at location.");
                }
            }
        }
    }
}
