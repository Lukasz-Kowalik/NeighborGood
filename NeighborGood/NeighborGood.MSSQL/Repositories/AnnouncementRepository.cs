using Microsoft.EntityFrameworkCore;
using NeighborGood.Models.DTOs.Requests;
using NeighborGood.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace NeighborGood.MSSQL.Repositories
{
    public class AnnouncementRepository : IAnnouncementRepository<Announcement,AnnouncementFilter>
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

        public async Task<IEnumerable<Announcement>> GetFilteredAnnouncements(AnnouncementFilter filter)
        {
            if (filter.PriceUp <= filter.PriceDown)
                filter.PriceUp = decimal.MaxValue;

            var filteredAnnouncements = new List<Announcement>();
            var filtered = await _dbContext.Announcements.Where(x => x.Name == filter.Name
                || ((x.Price >= filter.PriceDown && x.Price <= filter.PriceUp))
                || x.AnnouncementType == filter.AnnouncementType
                || x.PublishingType == filter.PublishingType
                || x.Tags.Select(t => filter.Tags.Where(o=>o.Name == t.Name)).Any() // filter.Tags.Select(o => o.Name == t.Name).FirstOrDefault())
                ).ToListAsync();
            
            return filtered;
        }
    }
}