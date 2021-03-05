

using RestaturantRepository.Model;
using RestaturantRepository.Repository;
using System.Collections.Generic;

namespace RestaturantRepository.Interfaces
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetRestaurant();
        bool DeleteRestaurant(int Id);
        Restaurant GetRestaurantByID(int Id);
        bool InsertRestaurant(ResturantRequestModel restaurant);
        bool Save();
        bool UpdateRestaurant(ResturantRequestModel restaurant);
        IEnumerable<Restaurant> GetRestaurantMenu();
    }
}
