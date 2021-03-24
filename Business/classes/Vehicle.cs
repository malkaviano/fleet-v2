using System;
using System.ComponentModel.DataAnnotations;

namespace Business
{
    public abstract class Vehicle
    {
        [Required]
        public string Chassis { get; protected set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public VehicleCategory Category { get; protected set; }

        [Required]
        public byte Passenger { get; protected set; }

        public override string ToString()
        {
            return $@"
                Chassis: {this.Chassis}
                Color: {this.Color}
                Passengers: {this.Passenger}
                Category: {(this.Category == VehicleCategory.TRUCK ? "Truck" : "Bus")}
            ";
        }
    }
}
