using System.Collections.ObjectModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Business
{
    public class VehicleFactory
    {
        static public Vehicle Create(
            string chassis,
            string color,
            VehicleCategory category
        )
        {
            Vehicle vehicle;

            switch (category)
            {
                case VehicleCategory.BUS:
                    {
                        vehicle = new Bus(chassis, color);
                        break;
                    }
                case VehicleCategory.TRUCK:
                    {
                        vehicle = new Truck(chassis, color);
                        break;
                    }
                default:
                    throw new InvalidOperationException("Wrong Category");
            }

            var validationContext = new ValidationContext(vehicle);
            var validationResults = new Collection<ValidationResult>();

            var isValid = Validator.TryValidateObject(
                vehicle,
                validationContext,
                validationResults
            );

            if (!isValid)
            {
                var errorMsg = validationResults.Aggregate(
                    String.Empty,
                    (errors, vr) => string.Concat(errors, " | ", vr.ErrorMessage)
                );

                throw new Exception(errorMsg);
            }

            return vehicle;
        }
    }
}