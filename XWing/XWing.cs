
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace XWing
{
    public class XWing : IShip
    {
        private readonly IEngine _engine;
        private readonly IWeapon[] _weapons;
        private IShipState _shipState;
        public XWing(IEngine engine, IShipState shipState, IWeaponFactory[] weaponFactories)
        {
            _engine = engine;
            var weapons = new List<IWeapon>();
            for (var i = 0; i < 4; ++i)
            {
                weapons.Add(weaponFactories.FirstOrDefault(s => s.GetType() == typeof(KX9LaserCannonFactory)).Create());
            }
            for (var i = 0; i < 2; ++i)
            {
                weapons.Add(weaponFactories.FirstOrDefault(s => s.GetType() == typeof(KrupxMG7ProtonLauncherFactory)).Create());
            }
            _weapons = weapons.ToArray();
            _shipState = shipState;
        }

        public string GetShipType()
        {
            return "X-Wing";
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
            Console.WriteLine("XWing does not have a warp drive");
        }
        public void WarpToLocation(double galacticLongitude, double galacticLatitude)
        {
            if (!_engine.IsWarpDriveEnabled())
                Console.WriteLine("Warp drive not enabled. Unable to perform warp operation.");
        }
    }
}
