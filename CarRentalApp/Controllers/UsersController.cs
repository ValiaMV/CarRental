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
    public class UsersController : ControllerBase
    {
        private IUserManager _userManager;
        private readonly IMapper _mapper;

        public UsersController(IUserManager userManager, IMapper _mapper)
        {
            _userManager = userManager;
        }
        // GET: api/User
        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            var users = await _userManager.ReadAll();
            List<UserViewModel> usersView = new List<UserViewModel>();
            foreach(var user in users)
            {
                usersView.Add(new UserViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    LicenseNumber = user.LicenseNumber,
                    BirthDate = user.BirthDate.ToShortDateString()
                });
            }
            return usersView;
        }
    }
}
