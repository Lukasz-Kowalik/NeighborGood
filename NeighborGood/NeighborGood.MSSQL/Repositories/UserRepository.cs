using Microsoft.EntityFrameworkCore;
using NeighborGood.Models;
using NeighborGood.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborGood.MSSQL.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        protected NeighborGoodContext _dbContect;

        public UserRepository(NeighborGoodContext dbcontext)
        {
            _dbContect = dbcontext;
        }

        public async Task<int> CreateAsync(User entity)
        {
            var created = await _dbContect.Users.AddAsync(entity);
            await _dbContect.SaveChangesAsync();
            return created.Entity.Id;
        }

        public Task DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = await _dbContect.Users.ToListAsync();
            return users;
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
