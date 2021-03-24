using System;
using Business;
using Xunit;

namespace Tests
{
    public class BusTests
    {
        [Fact]
        public void CreateABusWithSuccess()
        {
            var bus = new Bus("xpto", "red");

            Assert.Equal(VehicleCategory.BUS, bus.Category);
            Assert.Equal("red", bus.Color);
            Assert.Equal(42, bus.Passenger);
            Assert.Equal("xpto", bus.Chassis);
        }

        [Fact]
        public void CreateABusFailWhenChassisIsNull()
        {
            Assert.Throws<Exception>(
                () => { new Bus(null, "red"); });
        }

        [Fact]
        public void CreateABusFailWhenColorIsNull()
        {
            Assert.Throws<Exception>(
                () => { new Bus("xpto", null); });
        }
    }
}
