using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptiTech.Application.Interfaces.Repositories;
using OptiTech.Application.Interfaces.Services;
using OptiTech.Core.Entities;

namespace OptiTech.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> CreateCustomerAsync(string name, string email)
        {
            var customer = new Customer(name, email);
            await _customerRepository.AddAsync(customer);
            return customer;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if(customer == null)
                throw new Exception("Customer not found");

            return customer;
        }
    }
}
