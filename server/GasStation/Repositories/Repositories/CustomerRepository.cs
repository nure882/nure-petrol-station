using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly AppContext _context;

        public CustomerRepository(AppContext context)
        {
            _context = context;
        }

        public List<Customer> Get(Func<Customer, bool> func)
        {
            var customers = _context.Customers.Where(func);
            return customers.ToList();
        }

        public async Task<Customer> Get(int customerId)
        {
            return await _context.Customers.Include(c => c.Coupons).ThenInclude(c => c.GasType).FirstOrDefaultAsync(c => c.UserId == customerId);
        }

        public async Task<Customer> Update(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
