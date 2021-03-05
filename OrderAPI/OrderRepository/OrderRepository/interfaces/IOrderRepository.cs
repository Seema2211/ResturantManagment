

using OrderRepository.Model;
using System.Collections.Generic;

namespace OrderRepository.interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrder();
        bool DeleteOrder(int Id);
        Order GetOrderByID(int Id);
        bool InsertOrder(Order order);
        bool Save();
        bool UpdateOrder(Order order);
    }
}
