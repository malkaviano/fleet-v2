using System.Collections.Generic;
using System;
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
            var bus = new Bus("xpto", "red");

            var repo = new MemoryRepo();

            var result = repo.Add(bus);

            Assert.Equal(bus, result);
        }

        [Fact]
        public void AddVehicleTwiceReturnsUpdatedVehicle()
        {
            var bus = new Bus("xpto", "red");

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

            var bus = new Bus("xpto", "red");
            var truck = new Truck("some", "blue");

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

            var bus = new Bus("xpto", "red");

            repo.Add(bus);

            var result = repo.Remove("xpto");

            Assert.Equal(bus, result);
        }
    }
}
