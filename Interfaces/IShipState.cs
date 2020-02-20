using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IShipState
    {
        public double CurrentLongitude { get; set; }
        public double CurrentLatitude { get; set; }
        public int CurrentSpeed { get; set; }
        public bool IsWarping { get; set; }
    }
}
