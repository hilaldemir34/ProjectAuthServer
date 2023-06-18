using AuthServer.Core.DTOs;
using AuthServer.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Exceptions;
using System.Threading.Tasks;

namespace ProjectAuthServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    { 
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;

        }
        [HttpPost]//methodun tipine göre eşleşme var
        public async Task<IActionResult>CreateUser(CreateUserDto createUserDto)
        {
            throw new CustomException("Veri tabanı ile ilgili bir hata meydana geldi");
            return ActionResultInstance(await _userService.CreateUserAsync(createUserDto));
        }
        [Authorize]//mutlaka token istiyor.
        [HttpGet]//sadece bu methodu authorization attribute ile işaretlediğimizde gelen token içinden user name al
        public async Task<IActionResult>GetUser()
        {
            return ActionResultInstance(await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
        }
    }

}
