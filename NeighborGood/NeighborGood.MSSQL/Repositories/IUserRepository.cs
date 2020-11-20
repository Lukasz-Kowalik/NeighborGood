using NeighborGood.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighborGood.MSSQL.Repositories
{
    public interface IUserRepository<T> : IRepository<T> where T:BaseModel
    {
        
    }
}
