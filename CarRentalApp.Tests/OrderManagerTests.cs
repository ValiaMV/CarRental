using AutoFixture.Xunit2;
using AutoMapper;
using CarRentalApp.Business.Managers;
using CarRentalApp.Business.Mapping;
using CarRentalApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarRentalApp.Tests
{
    public class OrderManagerTests
    {
        private readonly IMapper _mapper;
        public OrderManagerTests()
        {
            var mappingProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            _mapper = new Mapper(configuration);
        }
        [Fact]
        public async Task OrderReadAllTest()
        {
            var options = new DbContextOptionsBuilder<FakeContext>()
                .UseInMemoryDatabase(databaseName: nameof(OrderReadAllTest))
                .Options;
            using (var context = new FakeContext(options))
            {
                context.Orders.Add(new Data.Models.Order());
                context.SaveChanges();

                OrderManager manager = new OrderManager(context, _mapper);
                var orders = await manager.ReadAll();

                Assert.NotNull(orders);
                Assert.Equal(context.Orders.Count(), orders.Count());
            }
        }
        [Theory, AutoData]
        public void OrderCreateTest(Order order)
        {
            var options = new DbContextOptionsBuilder<FakeContext>()
                .UseInMemoryDatabase(databaseName: nameof(OrderCreateTest))
                .Options;
            using (var context = new FakeContext(options))
            {
                OrderManager manager = new OrderManager(context, _mapper);
                manager.Create(order);

                Assert.NotNull(context.Orders.SingleOrDefault(orderData => order.Id == orderData.Id));
            }
        }
        [Theory, AutoData]
        public void OrderDeleteTest(Data.Models.Order order)
        {
            var options = new DbContextOptionsBuilder<FakeContext>()
                .UseInMemoryDatabase(databaseName: nameof(OrderDeleteTest))
                .Options;
            using (var context = new FakeContext(options))
            {
                context.Orders.Add(order);
                context.SaveChanges();

                OrderManager manager = new OrderManager(context, _mapper);
                manager.Delete(order.Id);

                Assert.Null(context.Orders.SingleOrDefault( orderData => orderData.Id == order.Id));
            }
        }

        [Theory, AutoData]
        public void OrderUpdateTest(Data.Models.Order order, Order orderUpdate)
        {
            var options = new DbContextOptionsBuilder<FakeContext>()
                .UseInMemoryDatabase(databaseName: nameof(OrderUpdateTest))
                .Options;
            orderUpdate.Id = order.Id;
            using (var context = new FakeContext(options))
            {
                context.Orders.Add(order);
                context.SaveChanges();

                OrderManager manager = new OrderManager(context, _mapper);
                manager.Update(orderUpdate);

                Assert.Equal(context.Orders.Single(orderData => orderData.Id == order.Id).BeginDate,
                    orderUpdate.BeginDate);
                Assert.Equal(context.Orders.Single(orderData => orderData.Id == order.Id).EndDate,
                    orderUpdate.EndDate);
                Assert.Equal(context.Orders.Single(orderData => orderData.Id == order.Id).CarId,
                    orderUpdate.CarId);
                Assert.Equal(context.Orders.Single(orderData => orderData.Id == order.Id).UserId,
                    orderUpdate.UserId);
                Assert.Equal(context.Orders.Single(orderData => orderData.Id == order.Id).Comment,
                    orderUpdate.Comment);
            }
        }
        [Theory, AutoData]
        public async Task OrderFilterByBeginDateTest(Data.Models.Order[] orders, DateTime filterDate)
        {
            var options = new DbContextOptionsBuilder<FakeContext>()
                .UseInMemoryDatabase(databaseName: nameof(OrderFilterByBeginDateTest))
                .Options;
            using (var context = new FakeContext(options))
            {
                foreach(var order in orders.Take(orders.Length / 3))
                {
                    order.BeginDate = filterDate;
                }
                foreach (var order in orders)
                {
                    order.Id = 0;
                    context.Orders.Add(order);
                }
                context.SaveChanges();

                OrderManager manager = new OrderManager(context, _mapper);
                var filteredOrders = await manager.FilterByBeginDate(filterDate);

                Assert.NotNull(filteredOrders);
                foreach(var order in filteredOrders.ToList())
                {
                    Assert.Equal(filterDate, order.BeginDate);
                }
            }
        }
        [Theory, AutoData]
        public async Task OrderFilterByEndDateTest(Data.Models.Order[] orders, DateTime filterDate)
        {
            var options = new DbContextOptionsBuilder<FakeContext>()
                .UseInMemoryDatabase(databaseName: nameof(OrderFilterByEndDateTest))
                .Options;
            using (var context = new FakeContext(options))
            {
                foreach (var order in orders.Take(orders.Length / 3))
                {
                    order.EndDate = filterDate;
                }
                foreach (var order in orders)
                {
                    context.Orders.Add(order);
                }
                context.SaveChanges();

                OrderManager manager = new OrderManager(context, _mapper);
                var filteredOrders = await manager.FilterByEndDate(filterDate);

                Assert.NotNull(filteredOrders);
                foreach (var order in filteredOrders.ToList())
                {
                    Assert.Equal(filterDate, order.EndDate);
                }
            }
        }

        [Theory, AutoData]
        public async Task OrderFilterByNameTest(Data.Models.Order[] orders, string filterName)
        {
            var options = new DbContextOptionsBuilder<FakeContext>()
                .UseInMemoryDatabase(databaseName: nameof(OrderFilterByNameTest))
                .Options;
            using (var context = new FakeContext(options))
            {
                foreach (var order in orders.Take(orders.Length / 3))
                {
                    order.User.FirstName = filterName;
                }
                foreach (var order in orders)
                {
                    context.Orders.Add(order);
                }
                context.SaveChanges();

                OrderManager manager = new OrderManager(context, _mapper);
                var filteredOrders = await manager.FilterByUserName(filterName);

                Assert.NotNull(filteredOrders);
                foreach (var order in filteredOrders.ToList())
                {
                    Assert.Equal(filterName, order.User.FirstName);
                }
            }
        }
        [Theory, AutoData]
        public async Task OrderFilterByCarModelTest(Data.Models.Order[] orders, string filterModel)
        {
            var options = new DbContextOptionsBuilder<FakeContext>()
                .UseInMemoryDatabase(databaseName: nameof(OrderFilterByCarModelTest))
                .Options;
            using (var context = new FakeContext(options))
            {
                foreach (var order in orders.Take(orders.Length / 3))
                {
                    order.Id = 0;
                    order.Car.Model = filterModel;
                }
                foreach (var order in orders)
                {
                    context.Orders.Add(order);
                }
                context.SaveChanges();

                OrderManager manager = new OrderManager(context, _mapper);
                var filteredOrders = await manager.FilterByCarModel(filterModel);

                Assert.NotNull(filteredOrders);
                foreach (var order in filteredOrders.ToList())
                {
                    Assert.Equal(filterModel, order.Car.Model);
                }
            }
        }
        [Theory, AutoData]
        public async Task OrderFilterByCarVendorTest(Data.Models.Order[] orders, string filterVendor)
        {
            var options = new DbContextOptionsBuilder<FakeContext>()
                .UseInMemoryDatabase(databaseName: nameof(OrderFilterByCarVendorTest))
                .Options;
            using (var context = new FakeContext(options))
            {
                foreach (var order in orders.Take(orders.Length / 3))
                {
                    order.Car.Vendor = filterVendor;
                }
                foreach (var order in orders)
                {
                    context.Orders.Add(order);
                }
                context.SaveChanges();

                OrderManager manager = new OrderManager(context, _mapper);
                var filteredOrders = await manager.FilterByUserName(filterVendor);

                Assert.NotNull(filteredOrders);
                foreach (var order in filteredOrders.ToList())
                {
                    Assert.Equal(filterVendor, order.Car.Vendor);
                }
            }
        }
    }
}
