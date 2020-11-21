using Microsoft.EntityFrameworkCore;
using NeighborGood.Models.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeighborGood.MSSQL.Repositories
{
    public class AnnouncementRepository : IAnnouncementRepository<Announcement>
    {
        protected NeighborGoodContext _dbContext;

        public AnnouncementRepository(NeighborGoodContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<int> CreateAsync(Announcement entity)
        {
            var announcement = await _dbContext.Announcements.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return announcement.Entity.Id;
        }

        public async Task DeleteAsync(Announcement entity)
        {
            _dbContext.Announcements.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            _dbContext.Remove(await _dbContext.Announcements.FirstOrDefaultAsync(x => x.Id == id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Announcement>> GetAllAsync()
        {
            var announcements = await _dbContext.Announcements.ToListAsync();
            return announcements;
        }

        public async Task<Announcement> GetByIdAsync(int id)
        {
            var announcement = await _dbContext.Announcements.FirstOrDefaultAsync(x => x.Id == id);
            return announcement;
        }

        public async Task UpdateAsync(Announcement entity)
        {
            _dbContext.Announcements.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}