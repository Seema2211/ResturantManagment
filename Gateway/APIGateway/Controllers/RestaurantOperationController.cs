
using APIGateway.Model;
using APIGateway.Util;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantOperationController : ControllerBase
    {
        HttpClientUtil HttpClient = new HttpClientUtil();
        [HttpPost, Route("AssignDriver")]
        public async Task<bool> AssignDriver(AssignDealerRequestModel requestModel)
        {
            var order = await HttpClient.RunAsyncGet<int, Order>("https://localhost:44305/api/Order/GetOrderById", requestModel.OrderId);
            var driver = await HttpClient.RunAsyncGet<int, Driver>("https://localhost:44311/api/Driver/GetDriverById", requestModel.DriverId);
            order.DriverId = driver.Id;
            order.DriverName = driver.FirstName + " " + driver.LastName;
            bool isAdded = await HttpClient.RunAsyncPost<Order, bool>("https://localhost:44305/api/Order/UpdateOrder", order);
            return isAdded;
        }
    }
}
