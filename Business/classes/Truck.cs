using System;
using System.Collections.Generic;

namespace Business
{
    public class Truck : Vehicle
    {
        internal Truck(string chassis, string color)
        {
            this.Chassis = chassis;
            this.Color = color;
            this.Passenger = 2;
            this.Category = VehicleCategory.TRUCK;
        }
    }
}