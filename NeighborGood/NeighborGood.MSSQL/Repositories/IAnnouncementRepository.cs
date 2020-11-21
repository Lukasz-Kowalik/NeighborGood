using NeighborGood.Models.Base;
using NeighborGood.Models.DTOs.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeighborGood.MSSQL.Repositories
{
    public interface IAnnouncementRepository<T,E> where T : BaseModel where E : AnnouncementFilter
    {
        Task<int> CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteByIdAsync(int id);

        Task DeleteAsync(T entity);

        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetFilteredAnnouncements(E filter);
    }
}