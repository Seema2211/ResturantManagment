

namespace APIGateway.Model
{
    public class OrderDetails
    {
        public string RestaurantName { get; set; }
        public string CustomerName { get; set; }
        public bool IsDeliver { get; set; }
        public decimal Price { get; set; }
        public int Quntity { get; set; }
        public string Food { get; set; }
    }
}
