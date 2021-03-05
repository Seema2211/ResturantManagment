

using RestaturantRepository.Model;
using System.Collections.Generic;

namespace RestaturantRepository.Interfaces
{
    public interface IMenuRepository
    {
        Menu GetMenuByID(int Id);
        IEnumerable<Menu> GetMenu();
        bool DeleteMenu(int Id);
        bool InsertMenu(Menu menu);
        bool UpdateMenu(Menu menu);
        bool Save();
    }
}
