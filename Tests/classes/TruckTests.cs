using System;
using Business;
using Xunit;

namespace Tests
{
    public class TruckTests
    {
        [Fact]
        public void CreateATruckWithSuccess()
        {
            var truck = new Truck("some", "blue");

            Assert.Equal(VehicleCategory.TRUCK, truck.Category);
            Assert.Equal("blue", truck.Color);
            Assert.Equal(2, truck.Passenger);
            Assert.Equal("some", truck.Chassis);
        }

        [Fact]
        public void CreateATruckFailWhenChassisIsNull()
        {
            Assert.Throws<Exception>(
                () => { new Truck(null, "blue"); });
        }

        [Fact]
        public void CreateATruckFailWhenColorIsNull()
        {
            Assert.Throws<Exception>(
                () => { new Truck("some", null); });
        }
    }
}
