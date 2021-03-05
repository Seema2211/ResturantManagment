
using Microsoft.AspNetCore.Mvc;
using RestaturantRepository.Interfaces;
using RestaturantRepository.Model;
using System.Collections.Generic;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _repository;
        public MenuController(IMenuRepository repository)
        {
            _repository = repository;
        }

        [HttpGet, Route("GetMenu")]
        public IEnumerable<Menu> Get()
        {
            return _repository.GetMenu();
        }
        [HttpGet, Route("GetMenuById")]
        public Menu GetMenuById(int Id)
        {
            return _repository.GetMenuByID(Id);
        }
        [HttpPost, Route("AddMenu")]
        public bool InsertMenu(Menu menu)
        {
            return _repository.InsertMenu(menu);
        }
        [HttpPost, Route("UpdateMenu")]
        public bool UpdateMenu(Menu menu)
        {
            return _repository.UpdateMenu(menu);
        }
        [HttpDelete, Route("DeleteMenu")]
        public bool DeleteMenu(int id)
        {
            return _repository.DeleteMenu(id);
        }
    }
}
