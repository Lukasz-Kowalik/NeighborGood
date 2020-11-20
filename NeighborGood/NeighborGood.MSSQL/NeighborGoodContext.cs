using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NeighborGood.Models.Entity;
namespace NeighborGood.MSSQL
{
    public class NeighborGoodContext : DbContext
    {
        DbSet<User> Users { get; set; }

        public NeighborGoodContext(DbContextOptions options) : base(options)
        {

        }


    }
}
