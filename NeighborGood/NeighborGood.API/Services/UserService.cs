using AutoMapper;
using NeighborGood.API.DTOs.Responses;
using NeighborGood.API.Services.Interfaces;
using NeighborGood.Models.Entity;
using NeighborGood.MSSQL.Repositories;
using System.Threading.Tasks;

namespace NeighborGood.API.Services
{
    public class UserService : IUserService
    {
        //private readonly IUserRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(/*IUserRepository<User> userRepository,*/ IMapper mapper)
        {
            //_userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponse> GetUserById(int id)
        {
            //var user = await _userRepository.GetByIdAsync(id);
            //var response = _mapper.Map<UserResponse>(user);
            return null;
        }
    }
}