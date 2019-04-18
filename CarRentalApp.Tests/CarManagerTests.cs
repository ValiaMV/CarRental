using CarRentalApp.Business.Managers;
using CarRentalApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRentalApp.Business.Mapping;
using CarRentalApp.Business.Interfaces;

namespace CarRentalApp.Tests
{
    public class CarManagerTests
    {
        [Fact]
        public async Task CarReadAllTest()
        {
            var options = new DbContextOptionsBuilder<FakeContext>()
                .UseInMemoryDatabase(databaseName: nameof(CarReadAllTest))
                .Options;
            using (var context = new FakeContext(options))
            {
                context.Cars.Add(new Car());
                context.SaveChanges();

                var mappingProfile = new MappingProfile();
                var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
                var mapper = new Mapper(configuration);
                ICarManager carManager = new CarManager(context, mapper);
                var cars = await carManager.ReadAll();

                Assert.NotNull(cars);
                Assert.Equal(context.Cars.ToList().Count, cars.ToList().Count);
            }
        } 

    }
}

