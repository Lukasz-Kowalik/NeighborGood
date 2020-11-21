﻿using NeighborGood.Models.Base;
using NeighborGood.Models.Enums.Announcements;
using System.Collections.Generic;

namespace NeighborGood.Models.Entity
{
    public class Announcement : BaseModel
    {
        public Announcement()
        {
            Tags = new List<Tag>();
        }

        public virtual User User { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public AnnouncementTypes AnnouncementType { get; set; }
        public PublishingTypes PublishingType { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual Localization Localization { get; set; }
    }
}