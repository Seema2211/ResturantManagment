

using DriverRepository.ContextFile;
using DriverRepository.Interfaces;
using DriverRepository.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DriverRepository.Repository
{
    public class DriverOperationRepository: IDriverRepository
    {
        private readonly DriverContext _dbContext;

        public DriverOperationRepository(DriverContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Driver> GetDriver()
        {
            return _dbContext.Driver.ToList();
        }
        public bool DeleteDriver(int Id)
        {
            var driver = _dbContext.Driver.Find(Id);
            _dbContext.Driver.Remove(driver);
            return Save();
        }

        public Driver GetDriverByID(int Id)
        {
            return _dbContext.Driver.Find(Id);
        }
        public bool InsertDriver(Driver driver)
        {
            _dbContext.Add(driver);
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

        public bool UpdateDriver(Driver driver)
        {
            _dbContext.Entry(driver).State = EntityState.Modified;
            return Save();
        }
    }
}
