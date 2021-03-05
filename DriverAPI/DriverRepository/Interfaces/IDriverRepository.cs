

using DriverRepository.Model;
using System.Collections.Generic;

namespace DriverRepository.Interfaces
{
    public interface IDriverRepository
    {
        IEnumerable<Driver> GetDriver();
        bool DeleteDriver(int Id);
        Driver GetDriverByID(int Id);
        bool InsertDriver(Driver driver);
        bool Save();
        bool UpdateDriver(Driver driver);
    }
}
