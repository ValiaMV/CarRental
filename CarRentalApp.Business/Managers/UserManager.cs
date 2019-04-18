using CarRentalApp.Business.Interfaces;
using CarRentalApp.Business.Models;
using CarRentalApp.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using User = CarRentalApp.Business.Models.User;
using DomainUser = CarRentalApp.Data.Models.User;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Business.Managers
{
    public class UserManager : IUserManager
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserManager(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<User>> ReadAll()
        {
            var users = _mapper.Map<IEnumerable<User>>(await _context.Users.ToListAsync());
            return users;
        }
    }
}
