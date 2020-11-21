using Microsoft.AspNetCore.Identity;

namespace NeighborGood.MSSQL.Repositories
{
    public interface IUserRepository<T> : IRepository<T> where T : IdentityUser<int>
    {
    }
}