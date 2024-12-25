using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WatchAPI.Datas.ViewModels;
using WatchAPI.Datas.ViewModels.Base;
using WatchAPI.Services;

namespace WatchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<BaseResponse<LoginRes>>> Login([FromBody] LoginReq model, CancellationToken cancellationToken)
        {
            var result = await _authService.Login(model, cancellationToken);
            return Ok(result);
        }
    }
}
