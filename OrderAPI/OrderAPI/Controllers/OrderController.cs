
using Microsoft.AspNetCore.Mvc;
using OrderRepository.interfaces;
using OrderRepository.Model;
using System.Collections.Generic;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repository;
        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }

        [HttpGet, Route("GetOrder")]
        public IEnumerable<Order> Get()
        {
            return _repository.GetOrder();
        }
        [HttpGet, Route("GetOrderById")]
        public Order GetOrderById(int Id)
        {
            return _repository.GetOrderByID(Id);
        }
        [HttpPost, Route("AddOrder")]
        public bool InsertOrder(Order order)
        {
            return _repository.InsertOrder(order);
        }
        [HttpPost, Route("UpdateOrder")]
        public bool UpdateOrder(Order order)
        {
            return _repository.UpdateOrder(order);
        }
        [HttpDelete, Route("DeleteOrder")]
        public bool DeleteOrder(int id)
        {
            return _repository.DeleteOrder(id);
        }
    }
}
