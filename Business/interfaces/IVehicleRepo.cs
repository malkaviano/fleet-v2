using System.Collections.Generic;
using System;

namespace Business
{
    public interface IVehicleRepo
    {
        IEnumerable<Vehicle> List();
        Vehicle Add(Vehicle vehicle);
        Vehicle Remove(string chassis);
    }
}