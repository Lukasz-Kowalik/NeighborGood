using Microsoft.EntityFrameworkCore;
using NeighborGood.Models.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighborGood.MSSQL.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        protected NeighborGoodContext _dbContext;

        public UserRepository(NeighborGoodContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<int> CreateAsync(User entity)
        {
            var user = await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return user.Entity.Id;
        }

        public async Task DeleteAsync(User entity)
        {
            _dbContext.Users.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            _dbContext.Remove(await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _dbContext.Users.FirstAsync(x => x.Id == id);
            return user;
        }

        public async Task UpdateAsync(User entity)
        {
            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetByEmailAcync(string email)
        {
            var user =await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }
    }
}