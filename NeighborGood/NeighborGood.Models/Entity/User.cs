using NeighborGood.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeighborGood.Models.Entity
{
    public class User : BaseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public decimal Rate { get; set; }
        public string PhoneNumber { get; set; }
    }
}
