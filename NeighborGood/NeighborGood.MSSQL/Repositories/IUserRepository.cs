using NeighborGood.Models.Base;

namespace NeighborGood.MSSQL.Repositories
{
    public interface IUserRepository<T> : IRepository<T> where T : BaseModel
    {
    }
}