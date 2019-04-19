using CarRentalApp.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp.Business.Interfaces
{
    public interface IOrderManager
    {
        Task<IEnumerable<Order>> ReadAll();
        Task<Order> Read(int id);
        void Create(Order order);
        void Update(Order order);
        void Delete(int id);
        Task<IEnumerable<Order>> FilterByBeginDate(DateTime date);
        Task<IEnumerable<Order>> FilterByEndDate(DateTime date);
        Task<IEnumerable<Order>> FilterByUserName(string name);
        Task<IEnumerable<Order>> FilterByCarModel(string name);
        Task<IEnumerable<Order>> FilterByCarVendor(string name);
    }
}
