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
        private DataContext _context;
        public UserManager(DataContext context)
        {
            _context = context;
            Mapper.Reset();
            Mapper.Initialize(config => config.CreateMap<DomainUser, User>());
        }
        public async Task<IEnumerable<User>> ReadAll()
        {
            var users = Mapper.Map<IEnumerable<DomainUser>, IEnumerable<User>>(await _context.Users.ToListAsync());
            return users;
        }
    }
}
