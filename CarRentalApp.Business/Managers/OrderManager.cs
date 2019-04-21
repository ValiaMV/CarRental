using AutoMapper;
using CarRentalApp.Business.Interfaces;
using CarRentalApp.Business.Models;
using CarRentalApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp.Business.Managers
{
    public class OrderManager : IOrderManager
    {
        private DataContext _context;
        private readonly IMapper _mapper;
        public OrderManager(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Create(Order order)
        {
             _context.Orders.Add(_mapper.Map<Data.Models.Order>(order));
             _context.SaveChanges();
        }

        public void Delete(int id)
        {
            if(id != 0)
            {
                _context.Orders.Remove(_context.Orders.Single( order => order.Id == id));
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Order>> ReadAll()
        {
            var ordersData = await _context.Orders.Include(ord => ord.Car).Include(ord => ord.User).ToListAsync();
            var orders = _mapper.Map<IEnumerable<Order>>(ordersData);
            return orders;
        }

        public void Update(Order orderUpdate)
        {
            var order = _context.Orders.Find(orderUpdate.Id);
            if(order != null)
            {
                _context.Entry(order).CurrentValues.SetValues(orderUpdate);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Order>> FilterByBeginDate(DateTime date)
        {
            if(date != DateTime.MinValue)
            {
                var orders = from order in _context.Orders.Include(ord => ord.Car).Include(ord => ord.User)
                             where order.BeginDate == date
                             select order;
                return _mapper.Map<IEnumerable<Order>>(await orders.ToListAsync());
            }
            return new List<Order>();
        }

        public async Task<IEnumerable<Order>> FilterByEndDate(DateTime date)
        {
            if (date != DateTime.MinValue)
            {
                var orders = from order in _context.Orders.Include(ord => ord.Car).Include(ord => ord.User)
                             where order.EndDate == date
                             select order;
                return _mapper.Map<IEnumerable<Order>>(await orders.ToListAsync());
            }
            return new List<Order>();
        }

        public async Task<IEnumerable<Order>> FilterByUserName(string name)
        {
            if (name != null)
            {
                var orders = from order in _context.Orders.Include(ord => ord.Car).Include(ord => ord.User)
                             where order.User.FirstName == name || order.User.LastName == name 
                             select order;
                return _mapper.Map<IEnumerable<Order>>(await orders.ToListAsync());
            }
            return new List<Order>();
        }
        public async Task<IEnumerable<Order>> FilterByCarModel(string model)
        {
            if (model != null)
            {
                var orders = from order in _context.Orders.Include(ord => ord.Car).Include(ord => ord.User)
                             where order.Car.Model == model
                             select order;
                return _mapper.Map<IEnumerable<Order>>(await orders.ToListAsync());
            }
            return new List<Order>();
        }
        public async Task<IEnumerable<Order>> FilterByCarVendor(string vendor)
        {
            if (vendor != null)
            {
                var orders = from order in _context.Orders.Include(ord => ord.Car).Include(ord => ord.User)
                             where order.Car.Vendor == vendor
                             select order;
                return _mapper.Map<IEnumerable<Order>>(await orders.ToListAsync());
            }
            return new List<Order>();
        }

        public async Task<Order> Read(int id)
        {
            return _mapper.Map<Order>(await _context.Orders.SingleOrDefaultAsync(order => order.Id == id));
        }
    }
}
