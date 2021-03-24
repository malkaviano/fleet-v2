using System.Runtime.Intrinsics.X86;
using System;
using Business;
using Xunit;

namespace Tests
{
    public class VehicleFactoryTests
    {
        [Fact]
        public void CreateAVehicleWithSuccess()
        {
            var factory = new VehicleFactory();

            var vehicle = VehicleFactory.Create("some", "blue", VehicleCategory.TRUCK);

            /*
                Why not implement the object Equals?
                Mostly because the only purpose would be to test
                Vehicles are the same if the chassis is the same!!!
            */
            Assert.Equal("some", vehicle.Chassis);
            Assert.Equal("blue", vehicle.Color);
            Assert.Equal(VehicleCategory.TRUCK, vehicle.Category);
            Assert.Equal(2, vehicle.Passenger);

            vehicle = VehicleFactory.Create("xpto", "red", VehicleCategory.BUS);

            Assert.Equal("xpto", vehicle.Chassis);
            Assert.Equal("red", vehicle.Color);
            Assert.Equal(VehicleCategory.BUS, vehicle.Category);
            Assert.Equal(42, vehicle.Passenger);
        }

        [Fact]
        public void CreateAVehicleFailWhenChassisIsNull()
        {
            Assert.Throws<Exception>(
                () => { VehicleFactory.Create(null, "green", VehicleCategory.BUS); });
        }

        [Fact]
        public void CreateAVehicleFailWhenColorIsNull()
        {
            Assert.Throws<Exception>(
                () => { VehicleFactory.Create("good stuff", null, VehicleCategory.TRUCK); });
        }
    }
}
