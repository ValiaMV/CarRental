using CarRentalApp.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp.Business.Interfaces
{
    public interface IUserManager
    {
        Task<IEnumerable<User>> ReadAll();
    }
}
