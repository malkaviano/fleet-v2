using System;
using System.Collections.Generic;

namespace Business
{
    public class Bus : Vehicle
    {
        internal Bus(string chassis, string color)
        {
            this.Chassis = chassis;
            this.Color = color;
            this.Passenger = 42;
            this.Category = VehicleCategory.BUS;
        }
    }
}