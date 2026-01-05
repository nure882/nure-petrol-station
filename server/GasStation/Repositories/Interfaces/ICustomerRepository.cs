using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<Customer> Get(int customerId);
        public List<Customer> Get(Func<Customer, bool> func);
        public Task<Customer> Update(Customer customer);
    }
}
