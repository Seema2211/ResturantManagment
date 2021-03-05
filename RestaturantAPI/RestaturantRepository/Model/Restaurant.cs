

using RestaturantRepository.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaturantRepository.Repository
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        [ForeignKey("Menu")]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
