using Logic.Interfaces;
using Logic.ViewModels;
using Repositories.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    internal class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> Get(CustomerSearchViewModel model)
        {
            return _customerRepository.Get(c =>
            ((string.IsNullOrEmpty(model.Name) || c.Name.Contains(model.Name)) &&
            ((string.IsNullOrEmpty(model.Surname) || c.Surname.Contains(model.Surname)) &&
            ((string.IsNullOrEmpty(model.Email) || c.Email.Contains(model.Email))))));
        }

        public async Task<Customer> Get(int customerId)
        {
            return await _customerRepository.Get(customerId);
        }

        public async Task<Customer> Update(Customer customer)
        {
            return await _customerRepository.Update(customer);
        }
    }
}
