using CarRentalApp.Business.Interfaces;
using CarRentalApp.Business.Models;
using CarRentalApp.Data;
using CarRentalApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Car = CarRentalApp.Business.Models.Car;
using DomainCar = CarRentalApp.Data.Models.Car;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Business.Managers
{
    public class CarManager : ICarManager
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CarManager(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Car>> ReadAll()
        {
            var cars = _mapper.Map<IEnumerable<Car>>(await _context.Cars.ToListAsync());
            return cars;
        }

        public async Task<IEnumerable<Car>> ReadFree()
        {
            var orderCars = from order in _context.Orders select order.CarId;
            var freeCars = from car in _context.Cars
                           where !orderCars.Contains(car.Id)
                           select car ;
            var cars = _mapper.Map<IEnumerable<Car>>(await freeCars.ToListAsync());
            return cars;
        }

        public async Task<IEnumerable<Car>> ReadFreeWithOrder(int id)
        {
            var orderCars = from order in _context.Orders where order.Id != id select order.CarId;
            var freeCars = from car in _context.Cars
                           where !orderCars.Contains(car.Id)
                           select car;
            var cars = _mapper.Map<IEnumerable<Car>>(await freeCars.ToListAsync());
            return cars;
        }
    }
}
