using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NeighborGood.Models.Entity;

namespace NeighborGood.MSSQL
{
    public class NeighborGoodContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<User> Users { get; set; }


        public NeighborGoodContext(DbContextOptions<NeighborGoodContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}