

using Microsoft.EntityFrameworkCore;
using OrderRepository.ContextFile;
using OrderRepository.interfaces;
using OrderRepository.Model;
using System.Collections.Generic;
using System.Linq;

namespace OrderRepository.Repository
{
    public class OrderOperation: IOrderRepository
    {
        private readonly OrderContext _dbContext;

        public OrderOperation(OrderContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Order> GetOrder()
        {
            var r =  _dbContext.Order.ToList();
            return r;
        }
        public bool DeleteOrder(int Id)
        {
            var order = _dbContext.Order.Find(Id);
            _dbContext.Order.Remove(order);
            return Save();
        }

        public Order GetOrderByID(int Id)
        {
            return _dbContext.Order.Find(Id);
        }
        public bool InsertOrder(Order order)
        {
            _dbContext.Add(order);
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

        public bool UpdateOrder(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            return Save();
        }
    }
}
