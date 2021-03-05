using Microsoft.EntityFrameworkCore;
using RestaturantRepository.ContextFile;
using RestaturantRepository.Interfaces;
using RestaturantRepository.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestaturantRepository.Repository
{
    public class MenuRepository: IMenuRepository
    {
        private readonly RestaurantContext _dbContext;
        public MenuRepository(RestaurantContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Menu GetMenuByID(int Id)
        {
            return _dbContext.Menu.Find(Id);
        }

        public IEnumerable<Menu> GetMenu()
        {
            return _dbContext.Menu.ToList();
        }
        public bool DeleteMenu(int Id)
        {
            var menu = _dbContext.Menu.Find(Id);
            _dbContext.Menu.Remove(menu);
            return Save();
        }
        public bool InsertMenu(Menu menu)
        {
            _dbContext.Add(menu);
            return Save();
        }
        public bool UpdateMenu(Menu menu)
        {
            _dbContext.Entry(menu).State = EntityState.Modified;
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
    }
}
