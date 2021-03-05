

using System.Collections.Generic;

namespace APIGateway.Model
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int MenuId { get; set; }
        public Menu menu { get; set; }
    }
}
