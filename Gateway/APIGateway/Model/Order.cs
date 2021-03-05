﻿

using System;

namespace APIGateway.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Nullable<int> DriverId { get; set; }
        public string DriverName { get; set; }
        public bool IsDeliver { get; set; }
        public Nullable<DateTime> Date { get; set; }
    }
}
