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
    public class CarsController : ControllerBase
    {
        private ICarManager _carManager;
        private readonly IMapper _mapper;

        public CarsController(ICarManager carManager, IMapper mapper)
        {
            _carManager = carManager;
            _mapper = mapper;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<CarViewModel>> GetCars()
        {
            var cars = _mapper.Map<IEnumerable<CarViewModel>>(await _carManager.ReadAll());
            return cars;
        }
        [Route("free")]
        [HttpGet]
        public async Task<IEnumerable<CarViewModel>> GetFreeCars()
        {
            var cars = _mapper.Map<IEnumerable<CarViewModel>>(await _carManager.ReadFree());
            return cars;
        }
        [Route("free/{id}")]
        [HttpGet]
        public async Task<IEnumerable<CarViewModel>> GetFreeCars(int id)
        {
            var cars = _mapper.Map<IEnumerable<CarViewModel>>(await _carManager.ReadFreeWithOrder(id));
            return cars;
        }
    }
}
