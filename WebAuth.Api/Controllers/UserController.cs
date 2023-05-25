using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAuth.Api.Contracts.Dtos.Login;
using WebAuth.Api.Contracts.Dtos.Register;
using WebAuth.Api.Entities;
using WebAuth.Api.Services;

namespace WebAuth.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManagaer;
        private readonly RoleManager<ApplicationRole> _roleMAnager;
        private readonly IClaimsService _claimsService;
        private readonly IJwtTokenService _jwtTokenService;
        public UserController(UserManager<ApplicationUser> userManagaer, RoleManager<ApplicationRole> roleMAnager, IClaimsService claimsService, IJwtTokenService jwtTokenService)
        {
            _userManagaer = userManagaer;
            _roleMAnager = roleMAnager;
            _claimsService = claimsService;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            IdentityResult result;

            ApplicationUser newUser = new()
            {
                Email = userRegisterDto.Email,
                UserName = userRegisterDto.Email,
                SecurityStamp = new Guid().ToString(),
            };

            result = await _userManagaer.CreateAsync(newUser, userRegisterDto.Password!);

            if (!result.Succeeded)
            {
                return Conflict(new UserRegisterResultDto
                {
                    Succeesed = result.Succeeded,
                    Errors = result.Errors.Select(res => res.Description)
                });
            }

            //await SeedRoles();

            result = await _userManagaer.AddToRoleAsync(newUser, UserRoles.User);

            return CreatedAtAction(nameof(Register), new UserRegisterResultDto { Succeesed = true });
        }
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var user = await _userManagaer.FindByEmailAsync(userLoginDto.Email!);

            if (user != null && await _userManagaer.CheckPasswordAsync(user, userLoginDto.Password!))
            {
                var userClaims = await _claimsService.GetUserClaims(user);
                var token =  _jwtTokenService.GetUserClaimsAsync(userClaims);

                return Ok(new UserLoginResultDto
                {
                    Succeeded = true,
                    Token = new UserTokenDto
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo
                    }
                });
            }
            else
            {
                return Unauthorized(new UserLoginResultDto
                {
                    Succeeded = false,
                    Message = "The email and password combination was inavalid"
                });
            }
        }
    }
}