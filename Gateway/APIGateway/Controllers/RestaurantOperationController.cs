
using APIGateway.Model;
using APIGateway.Util;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        [HttpGet, Route("GetReport")]
        public async Task<List<Order>> GetReport(int restuarantId)
        {
            List<Order> orders = await HttpClient.RunAsyncGetAll<Order>("https://localhost:44305/api/Order/GetOrder");
            orders = orders.FindAll(x => x.RestaurantId == restuarantId && x.IsDeliver == true && (x.Date.Value.Month == DateTime.UtcNow.Month && x.Date.Value.Month == DateTime.UtcNow.Year));
            return orders;
        }

        [HttpPost, Route("GetDriverReport")]
        public async Task<List<Order>> GetDriverReport(ReportRequestModel reportRequest)
        {
            List<Order> report = new List<Order>();
            List<Order> orders = await HttpClient.RunAsyncGetAll<Order>("https://localhost:44305/api/Order/GetOrder");
            DateTime d1 = DateTime.UtcNow;
            // subtract the dates, and divide the total days by 30.4 (avg number of days per month)
            orders = orders.FindAll(x => x.RestaurantId == reportRequest.ResturantId && x.DriverId == reportRequest.DriverId && x.IsDeliver == true);
            foreach(Order order in orders)
            {
                if(order.Date != null)
                {
                    DateTime d2 = (DateTime)order.Date;
                    int months = (int)(Math.Floor(((d1 - d2).TotalDays / 30.4)));
                    if(months <= 2)
                    {
                        report.Add(order);
                    }
                }
            }
            return report;
        }
    }
}
