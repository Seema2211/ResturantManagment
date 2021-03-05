

using CustomerRepository.ContextFile;
using CustomerRepository.Interfaces;
using CustomerRepository.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CustomerRepository.Repository
{
    public class CustomerOperationRepository: ICustomerRepository
    {

        private readonly CustomerContext _dbContext;

        public CustomerOperationRepository(CustomerContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Customer> GetCustomer()
        {
            return _dbContext.Customer.ToList();
        }
        public bool DeleteCustomer(int Id)
        {
            var customer = _dbContext.Customer.Find(Id);
            _dbContext.Customer.Remove(customer);
            return Save();
        }

        public Customer GetCustomerByID(int Id)
        {
           var r =   _dbContext.Customer.Find(Id);
            return r;
        }
        public bool InsertCustomer(Customer customer)
        {
            _dbContext.Add(customer);
            return Save();
        }

        public bool Save()
        {
            if (_dbContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateCustomer(Customer customer)
        {
            _dbContext.Entry(customer).State = EntityState.Modified;
            return Save();
        }
    }
}
