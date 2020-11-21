using Microsoft.AspNetCore.Mvc;
using NeighborGood.Models.Entity;
using NeighborGood.MSSQL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeighborGood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly AnnouncementRepository _repository;

        public AnnouncementController(IAnnouncementRepository<Announcement> repository)
        {
            _repository = (AnnouncementRepository)repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Announcement>> GetAllAnnouncements()
        {
            var announcements = await _repository.GetAllAsync();
            return announcements;
        }

        [HttpGet("{id}")]
        public async Task<Announcement> GetAnnouncement(int id)
        {
            var announcement = await _repository.GetByIdAsync(id);
            return announcement;
        }

        [HttpPost]
        public async Task<int> CreateAnnouncement(Announcement announcement)
        {
            var id = await _repository.CreateAsync(announcement);
            return id;
        }

        [HttpDelete("{id}")]
        public async Task DeleteAnnouncement(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }
    }
}