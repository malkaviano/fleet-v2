using System.Collections.Generic;
using Business;
using Xunit;
using Repo;

namespace Tests
{
    public class MemoryRepoTests
    {
        [Fact]
        public void AddVehicleReturnsVehicle()
        {
            var bus = VehicleFactory.Create("xpto", "red", VehicleCategory.BUS);

            var repo = new MemoryRepo();

            var result = repo.Add(bus);

            Assert.Equal(bus, result);
        }

        [Fact]
        public void AddVehicleTwiceReturnsUpdatedVehicle()
        {
            var bus = VehicleFactory.Create("xpto", "red", VehicleCategory.TRUCK);

            var repo = new MemoryRepo();

            var result = repo.Add(bus);

            bus.Color = "yellow";

            result = repo.Add(bus);

            Assert.Equal("yellow", result.Color);
        }

        [Fact]
        public void ListAllVehiclesReturnsVehicles()
        {
            var repo = new MemoryRepo();

            var bus = VehicleFactory.Create("xpto", "red", VehicleCategory.BUS);
            var truck = VehicleFactory.Create("some", "blue", VehicleCategory.TRUCK);

            repo.Add(bus);
            repo.Add(truck);

            var result = repo.List();

            var expected = new List<Vehicle>()
            {
                bus,
                truck,
            };

            Assert.Equal(result, expected);
        }

        [Fact]
        public void ListAllVehiclesReturnsEmpty()
        {
            var repo = new MemoryRepo();

            var result = repo.List();

            Assert.Empty(result);
        }

        [Fact]
        public void RemoveVehicleReturnsNull()
        {
            var repo = new MemoryRepo();

            var result = repo.Remove("xpto");

            Assert.Null(result);
        }

        [Fact]
        public void RemoveVehicleReturnsVehicle()
        {
            var repo = new MemoryRepo();

            var bus = VehicleFactory.Create("xpto", "red", VehicleCategory.BUS);

            repo.Add(bus);

            var result = repo.Remove("xpto");

            Assert.Equal(bus, result);
        }
    }
}
