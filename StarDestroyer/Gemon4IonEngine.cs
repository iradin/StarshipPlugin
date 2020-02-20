using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarDestroyer
{
    public class Gemon4IonEngine : IEngine
    {
        private const int MAX_SPEED = 975;
        private const bool WARP_DRIVE_ENABLED = true;
        private bool isWarpDriveSpooled = false;
        private readonly IShipState _shipState;
        public Gemon4IonEngine(IShipState shipState)
        {
            _shipState = shipState;
        }

        public int GetMaxSpeed()
        {
            return MAX_SPEED;
        }

        public bool IsWarpDriveEnabled()
        {
            return WARP_DRIVE_ENABLED;
        }

        public void SetSpeed(int speed)
        {
            if (speed < 0)
                Console.WriteLine("Speed must be a positive value");
            else if (speed > GetMaxSpeed())
                Console.WriteLine($"Speed cannot exceed maximum speed of {GetMaxSpeed()}");
            else
            {
                Console.WriteLine($"Setting speed to {speed}");
                _shipState.CurrentSpeed = speed;
            }
        }

        public void SpoolWarpDrive()
        {
            isWarpDriveSpooled = true;
            Console.WriteLine("Spooled warp drive");
        }

        public int Warp()
        {
            if (!isWarpDriveSpooled)
            {
                Console.WriteLine("Warp drive must be spooled first to perform a warp");
                return -1;
            }
            else
                isWarpDriveSpooled = false;
            return 0;
        }
    }
}
