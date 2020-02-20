using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace XWing
{
    public class FourL4FusialThrusterEngine : IEngine
    {
        private const int MAX_SPEED = 1050;
        private const bool WARP_DRIVE_ENABLED = false;
        private readonly IShipState _shipState;
        public FourL4FusialThrusterEngine(IShipState shipState)
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
            Console.WriteLine("Ship warp drive disabled");
        }

        public int Warp()
        {
            Console.WriteLine("Ship warp drive disabled");
            return -1;
        }
    }
}
