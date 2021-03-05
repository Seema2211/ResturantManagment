using Microsoft.EntityFrameworkCore;
using RestaturantRepository.ContextFile;
using RestaturantRepository.Interfaces;
using RestaturantRepository.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestaturantRepository.Repository
{
    public class RestaurantOperation: IRestaurantRepository
    {
        private readonly RestaurantContext _dbContext;
        private readonly IMenuRepository _menuRepository;
        public RestaurantOperation(RestaurantContext dbContext, IMenuRepository menuRepository)
        {
            _dbContext = dbContext;
            _menuRepository = menuRepository;
        }
        public IEnumerable<Restaurant> GetRestaurant()
        {
            return _dbContext.Restaurant.ToList();
        }
        public IEnumerable<Restaurant> GetRestaurantMenu()
        {
           List<Restaurant> restaurant =  _dbContext.Restaurant.ToList();
           foreach(Restaurant res in restaurant)
            {
                Menu menu = _menuRepository.GetMenuByID(res.MenuId);
                res.Menu = menu;
            }
            return restaurant;
        }
        public bool DeleteRestaurant(int Id)
        {
            var restaurant = _dbContext.Restaurant.Find(Id);
            _dbContext.Restaurant.Remove(restaurant);
            return Save();
        }

        public Restaurant GetRestaurantByID(int Id)
        {
            return _dbContext.Restaurant.Find(Id);
        }
        
        public bool InsertRestaurant(ResturantRequestModel restaurant)
        {
            Restaurant res = new Restaurant();
            res.Menu = null;
            res.Id = restaurant.Id;
            res.Location = restaurant.Location;
            res.Name = restaurant.Name;
            res.MenuId = restaurant.MenuId;
            _dbContext.Add(res);
            return Save();
        }

        public bool Save()
        {
            if (_dbContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateRestaurant(ResturantRequestModel restaurant)
        {
            Restaurant res = new Restaurant();
            res.Menu = null;
            res.Id = restaurant.Id;
            res.Location = restaurant.Location;
            res.Name = restaurant.Name;
            res.MenuId = restaurant.MenuId;
            _dbContext.Entry(res).State = EntityState.Modified;
            return Save();
        }
    }
}
