
using DriverRepository.Interfaces;
using DriverRepository.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace DriverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverRepository _repository;
        public DriverController(IDriverRepository repository)
        {
            _repository = repository;
        }

        [HttpGet, Route("GetDriver")]
        public IEnumerable<Driver> Get()
        {
            return _repository.GetDriver();
        }
        [HttpGet, Route("GetDriverById")]
        public Driver GetDriverById(int Id)
        {
            return _repository.GetDriverByID(Id);
        }
        [HttpPost, Route("AddDriver")]
        public bool InsertDriver(Driver driver)
        {
            return _repository.InsertDriver(driver);
        }
        [HttpPost, Route("UpdateDriver")]
        public bool UpdateDriver(Driver driver)
        {
            return _repository.UpdateDriver(driver);
        }
        [HttpDelete, Route("DeleteDriver")]
        public bool DeleteDriver(int id)
        {
            return _repository.DeleteDriver(id);
        }
    }
}
