using APIGateway.Model;
using APIGateway.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverOperationController : ControllerBase
    {
        HttpClientUtil HttpClient = new HttpClientUtil();
        [HttpGet, Route("DriverOrders")]
        public async Task<List<Order>> AssignDriver(int driverId)
        {
            List<Order> orders = await HttpClient.RunAsyncGetAll<Order>("https://localhost:44305/api/Order/GetOrder");
            orders = orders.FindAll(x => x.DriverId == driverId);
            return orders;
        }
        [HttpGet, Route("DriverCurrentOrder")]
        public async Task<List<Order>> CurrentOrder(int driverId)
        {
            List<Order> orders = await HttpClient.RunAsyncGetAll<Order>("https://localhost:44305/api/Order/GetOrder");
            orders = orders.FindAll(x => x.DriverId == driverId && x.IsDeliver == false);
            return orders;
        }
        [HttpGet, Route("DriverDeliveredOrder")]
        public async Task<List<Order>> DeliveredOrder(int driverId)
        {
            List<Order> orders = await HttpClient.RunAsyncGetAll<Order>("https://localhost:44305/api/Order/GetOrder");
            orders = orders.FindAll(x => x.DriverId == driverId && x.IsDeliver == true);
            return orders;
        }
    }
}
