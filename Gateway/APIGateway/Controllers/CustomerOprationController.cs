using APIGateway.Model;
using APIGateway.Util;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerOprationController : ControllerBase
    {
        HttpClientUtil HttpClient = new HttpClientUtil();
        private readonly ILogger<CustomerOprationController> _logger;

        public CustomerOprationController(ILogger<CustomerOprationController> logger)
        {
            _logger = logger;
        }
        [HttpGet, Route("GetResturant")]
        public async Task<List<Restaurant>> GetResturant()
        {
            List<Restaurant> restaurant = await HttpClient.RunAsyncGetAll<Restaurant>("https://localhost:44335/api/Restaurant/GetRestaurantMenu");
            return restaurant;
        }
        [HttpPost, Route("GetOrder")]
        public async Task<bool> OrderFood(OrderRequestModel orderRequest)
        {
            var customer = await HttpClient.RunAsyncGet<int, Customer>("https://localhost:44349/api/Customer/GetCustomerById", orderRequest.CustomerId);
            Restaurant restaurant = await HttpClient.RunAsyncGet<int, Restaurant>("https://localhost:44335/api/Restaurant/GetRestaurantById", orderRequest.ResturantId);
            Order order = new Order();
            order.CustomerId = orderRequest.CustomerId;
            order.RestaurantId = orderRequest.ResturantId;
            order.RestaurantName = restaurant.Name;
            order.CustomerName = customer.FirstName + " " + customer.LastName;
            order.Date = DateTime.UtcNow;
            bool isAdded = await HttpClient.RunAsyncPost<Order, bool>("https://localhost:44305/api/Order/AddOrder", order);
            return isAdded;
        }
        [HttpGet, Route("GetCurrentOrder")]
        public async Task<List<OrderDetails>> CurrentOrder(int customerId)
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            List<Order> orders = await HttpClient.RunAsyncGetAll<Order>("https://localhost:44305/api/Order/GetOrder");
            List<Restaurant> restaurant = await HttpClient.RunAsyncGetAll<Restaurant>("https://localhost:44335/api/Restaurant/GetRestaurantMenu");
            foreach (Order order in orders)
            {
                OrderDetails details = new OrderDetails();
                if (order.IsDeliver == false && order.CustomerId == customerId)
                {
                    Menu menu = restaurant.Find(x => x.Id == order.RestaurantId).menu;
                    details.Price = menu.Price;
                    details.Quntity = menu.Quntity;
                    details.Food = menu.Food;
                    details.CustomerName = order.CustomerName;
                    details.RestaurantName = order.RestaurantName;
                    details.IsDeliver = order.IsDeliver;
                    orderDetails.Add(details);
                }
            }
            return orderDetails;
        }

        [HttpGet, Route("GetDeliveredOrder")]
        public async Task<List<OrderDetails>> DeliveredOrder(int customerId)
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            List<Order> orders = await HttpClient.RunAsyncGetAll<Order>("https://localhost:44305/api/Order/GetOrder");
            List<Restaurant> restaurant = await HttpClient.RunAsyncGetAll<Restaurant>("https://localhost:44335/api/Restaurant/GetRestaurantMenu");
            foreach (Order order in orders)
            {
                OrderDetails details = new OrderDetails();
                if (order.IsDeliver == true && order.CustomerId == customerId)
                {
                    Menu menu = restaurant.Find(x => x.Id == order.RestaurantId).menu;
                    details.Price = menu.Price;
                    details.Quntity = menu.Quntity;
                    details.Food = menu.Food;
                    details.CustomerName = order.CustomerName;
                    details.RestaurantName = order.RestaurantName;
                    details.IsDeliver = order.IsDeliver;
                    orderDetails.Add(details);
                }
            }
            return orderDetails;
        }
    }
}
