
using Microsoft.AspNetCore.Mvc;
using RestaturantRepository.Interfaces;
using RestaturantRepository.Model;
using RestaturantRepository.Repository;
using System.Collections.Generic;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository _repository;
        public RestaurantController(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        [HttpGet, Route("GetRestaurant")]
        public IEnumerable<Restaurant> Get()
        {
            return _repository.GetRestaurant();
        }
        [HttpGet, Route("GetRestaurantMenu")]
        public IEnumerable<Restaurant> GetRestaurantMenu()
        {
            return _repository.GetRestaurantMenu();
        }
        [HttpGet, Route("GetRestaurantById")]
        public Restaurant GetRestaurantById(int Id)
        {
            return _repository.GetRestaurantByID(Id);
        }
        [HttpPost, Route("AddRestaurant")]
        public bool InsertRestaurant(ResturantRequestModel restaurant)
        {
            return _repository.InsertRestaurant(restaurant);
        }
        [HttpPost, Route("UpdateRestaurant")]
        public bool UpdateRestaurant(ResturantRequestModel restaurant)
        {
            return _repository.UpdateRestaurant(restaurant);
        }
        [HttpDelete, Route("DeleteRestaurant")]
        public bool DeleteRestaurant(int id)
        {
            return _repository.DeleteRestaurant(id);
        }
    }
}
