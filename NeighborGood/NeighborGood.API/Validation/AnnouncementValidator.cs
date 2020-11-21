using FluentValidation;
using NeighborGood.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighborGood.API.Validation
{
    public class AnnouncementValidator:AbstractValidator<Announcement>
    {
        public AnnouncementValidator()
        {
            RuleFor(u => u.AnnouncementType).NotEmpty();
            RuleFor(u => u.Description).NotEmpty();
            RuleFor(u => u.Id).NotEmpty();
            RuleFor(u => u.Localization).NotEmpty();
            RuleFor(u => u.Price).NotEmpty();
            RuleFor(u => u.PublishingType).NotEmpty();
            RuleFor(u => u.Localization).NotEmpty();
        }
    }
}
