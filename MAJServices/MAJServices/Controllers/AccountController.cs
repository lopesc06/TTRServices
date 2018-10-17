using AutoMapper;
using MAJServices.Entities;
using MAJServices.Models;
using MAJServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MAJServices.Controllers
{
    [Route("api/users")]
    public class AccountController : Controller
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly RoleManager<RoleIdentity> _roleManager;
        private readonly SignInManager<UserIdentity> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<UserIdentity> userManager, SignInManager<UserIdentity> signInManager,
            IConfiguration configuration, RoleManager<RoleIdentity> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            this._configuration = configuration;
        }

//----------------------------Add a new user and return token--------------------------------------------//
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "ElevatedPrivilages")]
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
            var IdIsInUse = await _userManager.FindByIdAsync(userDto.Id);
            if (IdIsInUse != null)
            {
                return StatusCode(409, "UserId is already in use");
            }

            var CreateUserIdentity = Mapper.Map<UserIdentity>(userDto);
            CreateUserIdentity.UserName = CreateUserIdentity.Id;
            var result = await _userManager.CreateAsync(CreateUserIdentity, userDto.Password);
            if (result.Succeeded)
            {
                await AddUserRole(CreateUserIdentity, userDto.Role);
                var UserResultDto = Mapper.Map<UserDto>(CreateUserIdentity);
                var roles = await _userManager.GetRolesAsync(CreateUserIdentity);
                UserResultDto.Role = roles.Count>0 ? roles.First():null;
                return CreatedAtRoute("GetUser", new { id = UserResultDto.Id}, UserResultDto);
            }
            else
            {
                return BadRequest("Username or password invalid");
            }
        }
//----------------------------------Build Token For User---------------------------------------//
        private IActionResult BuildToken(UserIdentity userInfo, string role)
        {
            var memberOf = userInfo.DepartmentAcronym ?? "None";
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.LastName),
                new Claim("name",userInfo.Name),
                new Claim("department",memberOf),
                new Claim("roles",role),
                new Claim("username",userInfo.Id),
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
//--------------------------------Add User Role----------------------------------------------------------//
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "ElevatedPrivilages")]
        public async Task<IActionResult> AddUserRole(UserIdentity user, string role) {
            bool RoleExists = await _roleManager.RoleExistsAsync(role);
            role = RoleExists ? role : "General";
            bool UserHasRole = await _userManager.IsInRoleAsync(user, role);
            if (!UserHasRole)
            {
                var UserRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user,UserRoles);
                var result = await _userManager.AddToRoleAsync(user, role);
                if (result.Succeeded)
                    return Ok();
                else
                    return StatusCode(500, "A problem happened while handling your request");
            }
            else
            {
                return StatusCode(409, "User already has that role assigned");
            }
        }

//--------------------------------Login-----------------------------------------------------//
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LogIn userLogin)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userLogin.Username, userLogin.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByIdAsync(userLogin.Username);
                    var role = await _userManager.GetRolesAsync(user);
                    if (user == null && role == null)
                        return NoContent();
                    else
                        return BuildToken(user,role[0]);
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
