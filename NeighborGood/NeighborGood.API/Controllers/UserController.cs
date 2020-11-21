using Microsoft.AspNetCore.Mvc;
using NeighborGood.API.Services;
using NeighborGood.Models.Entity;
using NeighborGood.MSSQL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeighborGood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repository;
        private readonly GeoLocation _geoLocation;

        public UserController(IUserRepository<User> repository, GeoLocation geoLocation)
        {
            _repository = (UserRepository)repository;
            _geoLocation = geoLocation;
        }

        [HttpGet("GetCurrentLocation")]
        public string GetCurrentLocation(double latitude, double longitude )
        {
            return _geoLocation.GetCurrentTown(latitude, longitude);
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _repository.GetAllAsync();
            return users;
        }

        [HttpGet("{id}")]
        public async Task<User> GetUser(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            return user;
        }

        [HttpPost]
        public async Task<int> CreateUser(User user)
        {
            var id = await _repository.CreateAsync(user);
            return id;
        }

        [HttpDelete("{id}")]
        public async Task DeleteUser(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }
    }
}