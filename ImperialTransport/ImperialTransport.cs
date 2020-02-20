using Interfaces;
using System;
using System.Threading;

namespace ImperialTransport
{
    public class ImperialTransport : IShip
    {
        private readonly IEngine _engine;
        private readonly IShipState _shipState;
        public ImperialTransport(IShipState shipState, IEngine engine)
        {
            _engine = engine;
            _shipState = shipState;
        }
        public void ArmWeapon(int weaponId)
        {
            Console.WriteLine("No weapons equipped");
        }

        public void DisarmWeapon(int weaponId)
        {
            Console.WriteLine("No weapons equipped");
        }

        public void FireWeapon(int weaponId)
        {
            Console.WriteLine("No weapons equipped");
        }

        public string GetShipType()
        {
            return "Lambda-class T-4a Imperial Shuttle";
        }

        public double GetSpeed()
        {
            return _shipState.CurrentSpeed;
        }

        public IWeapon[] GetWeapons()
        {
            return null;
        }

        public void LoadWeapon(int weaponId, int ammoAmmount)
        {
            Console.WriteLine("No weapons equipped");
        }

        public void ReadyWarpDrive()
        {
            _engine.SpoolWarpDrive();
        }

        public void SetSpeed(int kps)
        {
            _engine.SetSpeed(kps);
        }

        public void WarpToLocation(double galacticLongitude, double galacticLatitude)
        {
            if (!_engine.IsWarpDriveEnabled())
                Console.Out.WriteLine("Warp drive not enabled. Unable to perform warp operation.");
            else
            {
                var result = _engine.Warp();
                if (result >= 0)
                {
                    Console.Out.WriteLine("Warping to location...");
                    Thread.Sleep(3000);
                    _shipState.CurrentLongitude = galacticLongitude;
                    _shipState.CurrentLatitude = galacticLatitude;
                    Console.WriteLine("Arrived at location.");
                }
            }
        }
    }
}
