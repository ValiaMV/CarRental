using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CarRentalApp.Data.Models;
using CarRentalApp.Business.Managers;
using System.Linq;
using CarRentalApp.Business.Mapping;
using AutoMapper;
using CarRentalApp.Business.Interfaces;

namespace CarRentalApp.Tests
{
    public class UserManagerTests
    {
        [Fact]
        public async Task UserReadAllTest()
        {
            var options = new DbContextOptionsBuilder<FakeContext>()
                .UseInMemoryDatabase(databaseName: nameof(UserReadAllTest))
                .Options;
            using (var context = new FakeContext(options))
            {
                context.Users.Add(new User());
                context.SaveChanges();

                var mappingProfile = new MappingProfile();
                var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
                Mapper.Initialize(cfg => cfg.AddProfile(mappingProfile));
                var mapper = new Mapper(configuration);
                IUserManager manager = new UserManager(context, mapper);
                var users = await manager.ReadAll();

                Assert.NotNull(users);
                Assert.Equal(context.Users.Count(), users.Count());
            }
        }
    }
}
