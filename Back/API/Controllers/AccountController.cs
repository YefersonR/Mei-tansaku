using Core.Application.DTOS.Account;
using Core.Application.Inferfaces.Service;
using Core.Application.ViewModels.User;
using Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace MeiTansaku.WebApi.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly AuthenticationResponse user;

        public AccountController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Authentication([FromBody] LoginViewModel request)
        {
            return Ok(await _userService.Login(request));
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserSaveViewModel request)
        {
            //var origin = Request.Headers["Origin"];
            int typeUser = 0;
            return Ok(await _userService.Regiter(request, typeUser));
        }

        [HttpPost("registerSeller")]
        public async Task<IActionResult> RegisterAdmin([FromBody] UserSaveViewModel request)
        {
            //var origin = Request.Headers["Origin"];
            int typeUser = 1;
            return Ok(await _userService.Regiter(request, typeUser));
        }
    }
}
