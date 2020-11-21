using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NeighborGood.API.DTOs.Requests;
using NeighborGood.API.Services.Interfaces;
using NeighborGood.Models.DTOs.Requests;
using NeighborGood.Models.Entity;
using NeighborGood.MSSQL.Repositories;
using System.Threading.Tasks;

namespace NeighborGood.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public UserService(IUserRepository<User> userRepository, IMapper mapper, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> RegisterUserAsync(RegisterUserRequest registerUser)
        {
            var user = _mapper.Map<User>(registerUser);
            user.UserName = user.Name;
            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return true;
            }
            return false;
        }

        public async Task<bool> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _userRepository.GetByEmailAcync(loginRequest.Email);
            if (user != null)
            {
            await    _signInManager.SignOutAsync();
               var result= await _signInManager.PasswordSignInAsync(user.UserName, loginRequest.Password, false, false);
                if(result.Succeeded)
                return true;
            }
            return false;
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        //    public async Task<UserResponse> GetUserById(int id)
        //    {
        //        var user = await _userRepository.GetByIdAsync(id);
        //        var response = _mapper.Map<UserResponse>(user);
        //        return response;
        //    }
    }
}