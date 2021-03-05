using CustomerRepository.Interfaces;
using CustomerRepository.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet, Route("GetCustomer")]
        public IEnumerable<Customer> Get()
        {
            return _repository.GetCustomer();
        }
        [HttpGet, Route("GetCustomerById")]
        public Customer GetCustomerById(int Id)
        {
            return _repository.GetCustomerByID(Id);
        }
        [HttpPost, Route("AddCustomer")]
        public bool InsertCustomer(Customer customer)
        {
            return _repository.InsertCustomer(customer);
        }
        [HttpPost, Route("UpdateCustomer")]
        public bool UpdateCustomer(Customer customer)
        {
            return _repository.UpdateCustomer(customer);
        }
        [HttpDelete, Route("DeleteCustomer")]
        public bool DeleteCustomer(int id)
        {
            return _repository.DeleteCustomer(id);
        }
    }
}
