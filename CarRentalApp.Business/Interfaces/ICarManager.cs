using CarRentalApp.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp.Business.Interfaces
{
    public interface ICarManager
    {
        Task<IEnumerable<Car>> ReadAll();
        Task<IEnumerable<Car>> ReadFree();
        Task<IEnumerable<Car>> ReadFreeWithOrder(int id);
    }
}
