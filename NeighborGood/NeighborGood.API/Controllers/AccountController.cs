using Microsoft.AspNetCore.Mvc;
using NeighborGood.API.DTOs.Responses;
using NeighborGood.API.Services.Interfaces;
using NeighborGood.Models.Entity;
using NeighborGood.MSSQL.Repositories;
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

        [HttpGet]
        [Route("GetUser/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
           var result =await _userService.GetUserById(id);
            return Ok();
        }
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUser()
        {
         //  var result = await _userService.GetUserById();
            return Ok();
        }
    }
}