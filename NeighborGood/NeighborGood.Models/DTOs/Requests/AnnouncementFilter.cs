using NeighborGood.Models.Entity;
using NeighborGood.Models.Enums.Announcements;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeighborGood.Models.DTOs.Requests
{
    public class AnnouncementFilter
    {
        public AnnouncementFilter()
        {
            Tags = new List<Tag>();
        }
        public string Name { get; set; }
        public decimal PriceDown { get; set; }
        public decimal PriceUp { get; set; }
        public AnnouncementTypes AnnouncementType { get; set; }
        public PublishingTypes PublishingType { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual Localization Localization { get; set; }
    }
}
