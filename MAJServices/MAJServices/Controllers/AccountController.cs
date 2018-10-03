using AutoMapper;
using MAJServices.Entities;
using MAJServices.Models;
using MAJServices.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MAJServices.Controllers
{
    [Route("api/users")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this._configuration = configuration;
        }

//----------------------------Add a new user and return token--------------------------------------------//
        [HttpPost("createuser")]
        public async Task<IActionResult> AddUserAsync([FromBody]UserForCreationDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var CreateUser = Mapper.Map<Entities.User>(userDto);
            CreateUser.UserName = CreateUser.Id;
            var result = await _userManager.CreateAsync(CreateUser, userDto.Password);
            if (result.Succeeded)
            {
                return BuildToken(CreateUser, userDto.Role);
            }
            else
            {
                return BadRequest("Username or password invalid");
            }
        }
//----------------------------------Build Token For User---------------------------------------//
        private IActionResult BuildToken(User userInfo, string role)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.LastName),
                new Claim("Name",userInfo.Name),
                new Claim("Role",role),
                new Claim("Username",userInfo.Id),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Llave_secreta"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddDays(30);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: _configuration["JwtIssuer"],
               audience: _configuration["JwtAudience"],
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration
            });

        }

//--------------------------------Login-----------------------------------------------------//
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] CredentialsViewModel userLogin)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userLogin.Username, userLogin.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = _userManager.FindByIdAsync(userLogin.Username);
                    if (user.Result == null)
                        return NoContent();
                    else
                        return BuildToken(user.Result,"admin");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
