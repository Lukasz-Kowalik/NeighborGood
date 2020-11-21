using Microsoft.AspNetCore.Mvc;
using NeighborGood.Models.Entity;
using NeighborGood.MSSQL.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeighborGood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repository;

        public UserController(IUserRepository<User> repository)
        {
            _repository = (UserRepository)repository;
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