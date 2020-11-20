using Microsoft.EntityFrameworkCore;
using NeighborGood.Models.Entity;
using System;
using System.Collections.Generic;
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

        public async Task DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = await _dbContect.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user =await _dbContect.Users.FirstAsync(x=>x.Id==id);
            return user;
        }

        public async Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}