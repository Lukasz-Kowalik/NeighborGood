using NeighborGood.API.DTOs.Requests;
using NeighborGood.Models.DTOs.Requests;
using System.Threading.Tasks;

namespace NeighborGood.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterUserRequest registerUser);
        Task<bool> LoginAsync(LoginRequest loginRequest);
        Task LogOutAsync();

        //Task<UserResponse> GetUserById(int id);
    }
}