using Microsoft.AspNetCore.Identity;
using NeighborGood.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeighborGood.Models.Entity
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }
    }
}
