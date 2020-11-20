using NeighborGood.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighborGood.MSSQL.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<int> CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteByIdAsync(int id);

        Task DeleteAsync(T entity);

        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();
    }
}
