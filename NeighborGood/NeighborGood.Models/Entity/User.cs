using Microsoft.AspNetCore.Identity;
using NeighborGood.Models.Base;
using NeighborGood.Models.Enums.Announcements;
using System.Collections.Generic;

namespace NeighborGood.Models.Entity
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            Announcements = new List<Announcement>();
        }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public UserTypes UserType { get; set; }
        public virtual List<Announcement> Announcements { get; set; }
    }
}