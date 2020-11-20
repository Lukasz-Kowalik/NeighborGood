using NeighborGood.Models.Base;
using NeighborGood.Models.Enums.Announcements;
using System.Collections.Generic;

namespace NeighborGood.Models.Entity
{
    public class User : BaseModel
    {
        public User()
        {
            Announcements = new List<Announcement>();
        }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public decimal Rate { get; set; }
        public string PhoneNumber { get; set; }
        public UserTypes UserType { get; set; }
        public virtual List<Announcement> Announcements { get; set; }
    }
}