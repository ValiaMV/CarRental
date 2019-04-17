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
    public class UserController : ControllerBase
    {
        private IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
            Mapper.Reset();
            Mapper.Initialize(config => config.CreateMap<User, UserViewModel>());
        }
        // GET: api/User
        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            var users = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(await _userManager.ReadAll());
            return users;
        }
    }
}
