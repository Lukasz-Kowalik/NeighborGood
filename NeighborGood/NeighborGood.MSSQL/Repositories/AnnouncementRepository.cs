using NeighborGood.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighborGood.MSSQL.Repositories
{
    public class AnnouncementRepository : IAnnouncementRepository<Announcement>
    {
        public Task<int> CreateAsync(Announcement entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Announcement entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Announcement>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Announcement> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Announcement entity)
        {
            throw new NotImplementedException();
        }
    }
}
