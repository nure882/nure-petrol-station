using GasStationMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GasStationMobile.Interfaces
{
    public interface IUserService
    {
        Task<Customer> GetUser(int userId);
        Task<Customer> UpdateUser(Customer customer);
    }
}
