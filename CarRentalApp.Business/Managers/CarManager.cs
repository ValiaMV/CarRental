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
    }
}
