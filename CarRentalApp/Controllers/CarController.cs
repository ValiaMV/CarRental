using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalApp.Business.Interfaces;
using CarRentalApp.Business.Managers;
using CarRentalApp.Business.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CarRentalApp.Models;

namespace CarRentalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private ICarManager _carManager;
        public CarController(ICarManager carManager)
        {
            _carManager = carManager;
            Mapper.Reset();
            Mapper.Initialize(config => config.CreateMap<Car, CarViewModel>());
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<CarViewModel>> GetCars()
        {
            var cars = Mapper.Map<IEnumerable<Car>, IEnumerable<CarViewModel>>(await _carManager.ReadAll());
            return cars;
        }
    }
}
