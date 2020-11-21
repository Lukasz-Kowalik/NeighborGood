﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NeighborGood.Models.Entity;

namespace NeighborGood.MSSQL
{
    public class NeighborGoodContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Localization> Localizations { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public NeighborGoodContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Announcement>().ToTable("Announcements");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Tag>().ToTable("Tags");
            modelBuilder.Entity<Localization>();
        }
    }
}