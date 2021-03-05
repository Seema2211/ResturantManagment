

using CustomerRepository.Model;
using System.Collections.Generic;

namespace CustomerRepository.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomer();
        bool DeleteCustomer(int Id);
        Customer GetCustomerByID(int Id);
        bool InsertCustomer(Customer customer);
        bool Save();
        bool UpdateCustomer(Customer customer);
    }
}
