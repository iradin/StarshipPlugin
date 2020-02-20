using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImperialTransport
{
    public class SFS240IonEngine : IEngine
    {
        private readonly IShipState _shipState;
        private const int MAX_SPEED = 850;
        private const bool WARP_DRIVE_ENABLED = true;
        private bool isWarpDriveSpooled = false;
        public SFS240IonEngine(IShipState shipState)
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
                Console.Out.WriteLine($"Invalid speed of {speed} engine cannot exceed {GetMaxSpeed()}");
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
