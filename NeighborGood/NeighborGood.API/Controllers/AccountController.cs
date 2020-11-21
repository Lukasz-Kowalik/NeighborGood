using Microsoft.AspNetCore.Mvc;
using NeighborGood.API.DTOs.Requests;
using NeighborGood.API.Services.Interfaces;
using NeighborGood.Models.DTOs.Requests;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NeighborGood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterUser(RegisterUserRequest request)
        {
            var result = await _userService.RegisterUserAsync(request);
            return result ? (IActionResult)Ok() : BadRequest();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _userService.LoginAsync(request);
            return result ? (IActionResult)Ok() : BadRequest();
        }

        [HttpPost]
        [Route("LogOut")]
        public async Task LogOut()
        {
            await _userService.LogOutAsync();
        }

        //[HttpGet]
        //[Route("GetUser/{id}")]
        //public async Task<IActionResult> GetUserById(int id)
        //{
        //   var result =await _userService.GetUserById(id);
        //    return Ok();
        //}
        //[HttpGet]
        //[Route("GetUsers")]
        //public async Task<IActionResult> GetUser()
        //{
        // //  var result = await _userService.GetUserById();
        //    return Ok();
        //}
    }
}