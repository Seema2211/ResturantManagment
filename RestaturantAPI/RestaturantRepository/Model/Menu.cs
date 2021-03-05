

using RestaturantRepository.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaturantRepository.Model
{
    public class Menu
    {
        public int Id { get; set; }
        public string Food { get; set; }
        public decimal Price { get; set; }
        public int Quntity { get; set; }

    }
}
