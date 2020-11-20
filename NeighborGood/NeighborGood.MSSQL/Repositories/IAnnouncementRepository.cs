using NeighborGood.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeighborGood.MSSQL.Repositories
{
    public interface IAnnouncementRepository<T> where T : BaseModel
    {
        Task<int> CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteByIdAsync(int id);

        Task DeleteAsync(T entity);

        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();
    }
}