using Microsoft.AspNetCore.Identity;
using NeighborGood.Models.Entity;
using System.Threading.Tasks;

namespace NeighborGood.MSSQL.Repositories
{
    public interface IUserRepository<T> : IRepository<T> where T : IdentityUser<int>
    {
        Task<User> GetByEmailAcync(string email);
    }
}