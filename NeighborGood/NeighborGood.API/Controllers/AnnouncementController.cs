using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NeighborGood.Models.DTOs.Requests;
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
        private readonly UserManager<User> _userManager;

        public AnnouncementController(UserManager<User> userManager ,IAnnouncementRepository<UserRegisterRequest,AnnouncementFilter> repository)
        {
            _repository = (AnnouncementRepository)repository;
            _userManager = userManager;
        }

        [HttpGet("filtered")]
        public async Task<IEnumerable<UserRegisterRequest>> GetFiltered(AnnouncementFilter filter)
        {
            var announcements = await _repository.GetFilteredAnnouncements(filter);
            return announcements;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<UserRegisterRequest>> GetAllAnnouncements()
        {
            var announcements = await _repository.GetAllAsync();
            return announcements;
        }

        [HttpGet("{id}")]
        public async Task<UserRegisterRequest> GetAnnouncement(int id)
        {
            var announcement = await _repository.GetByIdAsync(id);
            return announcement;
        }

        [HttpPost]
        public async Task<int> CreateAnnouncement(UserRegisterRequest announcement)
        {
            var user = await _userManager.GetUserAsync(User);
            announcement.UserId = user.Id;
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