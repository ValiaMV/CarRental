using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRentalApp.Business.Interfaces;
using CarRentalApp.Business.Managers;
using CarRentalApp.Business.Models;
using CarRentalApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderManager _orderManager;
        private readonly IMapper _mapper;
        public OrdersController(IOrderManager manager, IMapper mapper)
        {
            _orderManager = manager;
            _mapper = mapper;
        }
        // GET: api/Orders
        [HttpGet]
        public async Task<IEnumerable<OrderViewModel>> GetOrders()
        {
            var orders = _mapper.Map<IEnumerable<OrderViewModel>>(await _orderManager.ReadAll());
            return orders;
        }

        // GET: api/Orders/5
        [Route("{id}")]
        [HttpGet]
        public async Task<OrderViewModel> GetOrder(int id)
        {
            return _mapper.Map<OrderViewModel>(await _orderManager.Read(id));
        }
        [Route("start/{date}")]
        [HttpGet]
        public async Task<IEnumerable<OrderViewModel>> GetOrderByBeginDate(DateTime date)
        {
            return _mapper.Map<IEnumerable<OrderViewModel>>(await _orderManager.FilterByBeginDate(date));
        }
        [Route("end/{date}")]
        [HttpGet]
        public async Task<IEnumerable<OrderViewModel>> GetOrderByEndDate(DateTime date)
        {
            return _mapper.Map<IEnumerable<OrderViewModel>>(await _orderManager.FilterByEndDate(date));
        }
        [Route("name/{name}")]
        [HttpGet]
        public async Task<IEnumerable<OrderViewModel>> GetOrderByUserName(string name)
        {
            return _mapper.Map<IEnumerable<OrderViewModel>>(await _orderManager.FilterByUserName(name));
        }
        [Route("model/{model}")]
        [HttpGet]
        public async Task<IEnumerable<OrderViewModel>> GetOrderByCarModel(string model)
        {
            return _mapper.Map<IEnumerable<OrderViewModel>>(await _orderManager.FilterByCarModel(model));
        }
        [Route("vendor/{vendor}")]
        [HttpGet]
        public async Task<IEnumerable<OrderViewModel>> GetOrderByCarVendor(string vendor)
        {
            return _mapper.Map<IEnumerable<OrderViewModel>>(await _orderManager.FilterByCarVendor(vendor));
        }
        // POST: api/Orders
        [HttpPost]
        public void Post([FromBody] OrderViewModel order)
        {
            _orderManager.Create(_mapper.Map<Order>(order));
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public void Put([FromBody] OrderViewModel order)
        {
            if(ModelState.IsValid)
            {
                _orderManager.Update(_mapper.Map<Order>(order));
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if(id != 0)
            {
                _orderManager.Delete(id);
            }
        }
    }
}
