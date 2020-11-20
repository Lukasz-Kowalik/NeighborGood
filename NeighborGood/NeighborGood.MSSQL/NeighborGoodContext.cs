using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NeighborGood.MSSQL
{
    public class NeighborGoodContext : DbContext
    {
        public NeighborGoodContext(DbContextOptions options) : base(options)
        {

        }
    }
}
