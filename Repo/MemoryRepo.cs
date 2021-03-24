using System.Collections;
using System.Collections.Generic;
using System;
using Business;
using System.Linq;

namespace Repo
{
    public class MemoryRepo : IVehicleRepo
    {
        // Using a list so we can use Linq, a Dictionary would be easier
        private IList<Vehicle> repo;

        public MemoryRepo()
        {
            this.repo = new List<Vehicle>();
        }

        public Vehicle Add(Vehicle vehicle)
        {
            var current = this.FindByChassis(vehicle.Chassis);

            if (current == null)
            {
                this.repo.Add(vehicle);
            } else
            {
                current.Color = vehicle.Color;
            }

            return this.FindByChassis(vehicle.Chassis);
        }

        public IEnumerable<Vehicle> List() => this.repo;

        public Vehicle Remove(string chassis)
        {
            var current = this.FindByChassis(chassis);

            if (this.repo.Remove(current))
            {
                return current;
            }

            return null;
        }

        public Vehicle FindByChassis(string chassis) =>
            this.repo.SingleOrDefault(v => v.Chassis == chassis);
    }
}
