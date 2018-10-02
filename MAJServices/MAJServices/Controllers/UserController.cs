using AutoMapper;
using MAJServices.Entities;
using MAJServices.Models;
using MAJServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MAJServices.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private IUserInfoRepository _userInfoRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public UserController(IUserInfoRepository userInfoRepository, UserManager<User> userManager
            ,SignInManager<User> signInManager
            , IConfiguration configuration)
        {
            _userInfoRepository = userInfoRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }


//--------------Add a new user and return token--------------------------------------------//
        [HttpPost("adduser")]
        public async Task<IActionResult> AddUserAsync( [FromBody]UserForCreationDto userDto)
        {
            if(userDto == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var CreateUser = Mapper.Map<Entities.User>(userDto);
            CreateUser.UserName = CreateUser.Name;
            var result = await _userManager.CreateAsync(CreateUser, userDto.Password);
            if (result.Succeeded)
            {
                return BuildToken(CreateUser,userDto.Role);
            }
            else
            {
                return BadRequest("Username or password invalid");
            }
        }
//-------------------------Build Token For User---------------------------------------//
        private IActionResult BuildToken(User userInfo, string role)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.LastName),
                new Claim("Name",userInfo.Name),
                new Claim("Role",role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Llave_secreta"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "yourdomain.com",
               audience: "yourdomain.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration
            });

        }

//-------------------Get all Users with or without users' posts------------------------------------------------//
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet()]
        public ActionResult GetUsers(bool includePosts = false)
        {
            var users = _userInfoRepository.GetUsers(includePosts);
            IEnumerable result;
            if (includePosts)
            {
                result = Mapper.Map<IEnumerable<UserDto>>(users);
                foreach (UserDto r in result)
                {
                    var user = users.Where(u => u.Id == r.Id).FirstOrDefault();
                    r.UserPosts = Mapper.Map<List<PostDto>>(user.Posts);
                }
            }
            else
            {
                result = Mapper.Map<IEnumerable<UserWithoutPostsDto>>(users);
            }
            return Ok(result);
        }

//----------------Get User with or without user's posts------------------------------------------------------//
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult GetUser(string id, bool includePosts = false)
        {
            var user = _userInfoRepository.GetUser(id, includePosts);
            if (user == null)
                return NotFound();
            if (includePosts)
            {
                var result = Mapper.Map<UserDto>(user);
                result.UserPosts = Mapper.Map<List<PostDto>>(user.Posts);
                return Ok(result);
            }
            else
            {
                var result = Mapper.Map<UserWithoutPostsDto>(user);
                return Ok(result);
            }
        }
//-----------------------------------Delete User-----------------------------------//
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(string id)
        {
            if (!_userInfoRepository.UserExist(id))
            {
                return NotFound();
            }
            var UserEntity = _userInfoRepository.GetUser(id, false);
            if (UserEntity == null)
            {
                return NotFound();
            }
            _userInfoRepository.DeleteUser(UserEntity);

            if (!_userInfoRepository.SaveUser())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }
            return NoContent();
        }
    }
}

