using Microsoft.AspNetCore.Mvc;
using NeighborGood.Models.Entity;
using NeighborGood.MSSQL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighborGood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController: ControllerBase
    {
        private readonly AnnouncementRepository _repository;

        public AnnouncementController(IAnnouncementRepository<Announcement> repository)
        {
            _repository = (AnnouncementRepository)repository;
        }

        [HttpGet("Announcement/{id}")]
        public async Task<IEnumerable<Announcement>> GetAnnouncement()
        {
            var announcements = await _repository.GetAllAsync();
            return announcements;
        }
    }
}
