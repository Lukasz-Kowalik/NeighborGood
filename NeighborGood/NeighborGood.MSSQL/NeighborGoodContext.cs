using Microsoft.EntityFrameworkCore;
using NeighborGood.Models.Entity;

namespace NeighborGood.MSSQL
{
    public class NeighborGoodContext : DbContext
    {
        private DbSet<User> Users { get; set; }

        public NeighborGoodContext(DbContextOptions options) : base(options)
        {
        }
    }
}