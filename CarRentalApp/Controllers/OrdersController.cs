using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRentalApp.Business.Interfaces;
using CarRentalApp.Business.Managers;
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
        [Route("single")]
        [HttpGet]
        public async Task<OrderViewModel> GetOrder(int id)
        {
            return _mapper.Map<OrderViewModel>(await _orderManager.Read(id));
        }
        [Route("begindate")]
        [HttpGet]
        public async Task<IEnumerable<OrderViewModel>> GetOrderByBeginDate(DateTime date)
        {
            return _mapper.Map<IEnumerable<OrderViewModel>>(await _orderManager.FilterByBeginDate(date));
        }
        // POST: api/Orders
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
