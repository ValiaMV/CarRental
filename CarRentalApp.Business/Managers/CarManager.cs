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
        private DataContext _context;
        public CarManager(DataContext context)
        {
            _context = context;
            Mapper.Reset();
            Mapper.Initialize(config => config.CreateMap<DomainCar, Car>());
        }

        public async Task<IEnumerable<Car>> ReadAll()
        {
            var cars = Mapper.Map<IEnumerable<DomainCar>, IEnumerable<Car>>(await _context.Cars.ToListAsync());
            return cars;
        }
    }
}
