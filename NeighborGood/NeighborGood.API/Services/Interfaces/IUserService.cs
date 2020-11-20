using NeighborGood.API.DTOs.Responses;
using System.Threading.Tasks;

namespace NeighborGood.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> GetUserById(int id);
    }
}