using Logic.ViewModels;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ICustomerService
    {
        public Task<Customer> Get(int customerId);
        public List<Customer> Get(CustomerSearchViewModel model);
        public Task<Customer> Update(Customer customer);
    }
}
