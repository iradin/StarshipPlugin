using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class ShipState : IShipState
    {
        public double CurrentLongitude { get; set; }
        public double CurrentLatitude { get; set; }
        public int CurrentSpeed { get; set; }
        public bool IsWarping { get; set; }
    }
}
