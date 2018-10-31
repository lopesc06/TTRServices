using AutoMapper;
using MAJServices.Entities;
using MAJServices.Models;
using MAJServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "ElevatedPrivilages")]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly RoleManager<RoleIdentity> _roleManager;
        private readonly UserManager<UserIdentity> _userManager;
        private IDepartmentInfoRepository _departmentInfoRepository;

        public UserController(IUserInfoRepository userInfoRepository, UserManager<UserIdentity> userManager
            , RoleManager<RoleIdentity> roleManager, IDepartmentInfoRepository departmentInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _departmentInfoRepository = departmentInfoRepository;
        }
        
//-------------------Get all Users with or without users' posts------------------------------------------------//
        
        [HttpGet()]
        public async Task<IActionResult> GetUsersAsync(bool includePosts = false)
        {
            var users = _userInfoRepository.GetUsers(includePosts);
            IEnumerable result;
            if (includePosts)
            {
                result = Mapper.Map<IEnumerable<UserDto>>(users);
                foreach (UserDto r in result)
                {
                    var user = users.FirstOrDefault(u => u.Id == r.Id);
                    var userRole =await _userManager.GetRolesAsync(user);
                    r.Role = userRole.Count > 0 ? userRole.First() : null;
                    //if (userRole.Count > 0)
                    //    r.Role = userRole.First();
                    r.UserPosts = Mapper.Map<List<PostWithoutUserDto>>(user.Posts);
                }
            }
            else
            {
                result = Mapper.Map<IEnumerable<UserWithoutPostsDto>>(users);
                foreach (UserWithoutPostsDto r in result)
                {
                    var user = users.FirstOrDefault(u => u.Id == r.Id);
                    var userRole = await _userManager.GetRolesAsync(user);
                    r.Role = userRole.Count > 0 ? userRole.First() : null;
                    //if (userRole.Count > 0)
                    //    r.Role = userRole.First();
                }
            }
            return Ok(result);
        }

//----------------Get User with or without user's posts------------------------------------------------------//
        
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUserAsync(string id, bool includePosts = false)
        {
            var user = _userInfoRepository.GetUser(id, includePosts);
            if (user == null)
                return NotFound();
            if (includePosts)
            {
                var result = Mapper.Map<UserDto>(user);
                var userRole = await _userManager.GetRolesAsync(user);
                if (userRole.Count > 0)
                    result.Role = userRole.First();
                result.UserPosts = Mapper.Map<List<PostWithoutUserDto>>(user.Posts);
                return Ok(result);
            }
            else
            {
                var result = Mapper.Map<UserWithoutPostsDto>(user);
                var userRole = await _userManager.GetRolesAsync(user);
                if (userRole.Count > 0)
                    result.Role = userRole.First();
                return Ok(result);
            }
        }
//-----------------------------------Delete User-----------------------------------//
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            if (!_userInfoRepository.UserExists(id))
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
//------------------------------------Full update of user---------------------------------------//
        [HttpPut("userupdate/{id}")]
        public async Task<IActionResult> UserUpdateAsync(string id, [FromBody]UserForUpdateDto userUpdate)
        {
            if (!_userInfoRepository.UserExists(id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid || userUpdate == null)
            {
                return BadRequest(ModelState);
            }
            //if()

            var UserEntity = _userInfoRepository.GetUser(id, false);
            //if (UserEntity == null)
            //{
            //    return NotFound();
            //}
            Mapper.Map(userUpdate, UserEntity);
            if (!_userInfoRepository.SaveUser())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }
            var getCurrentRole = await _userManager.GetRolesAsync(UserEntity);
            var removeCurrentRole = await _userManager.RemoveFromRoleAsync(UserEntity, getCurrentRole[0]);
            var UpdateWithNewRole = await _userManager.AddToRoleAsync(UserEntity, userUpdate.Role);
            if(!removeCurrentRole.Succeeded && !UpdateWithNewRole.Succeeded)
            {
                return StatusCode(500, "A problem happened while Updating User's Role request");
            }
            return NoContent();
        }

//----------------------------------------Partial User Update----------------------------//
        [HttpPatch("userupdate/{id}")]
        public async Task<IActionResult> PartialUserUpdateAsync(string id, [FromBody]JsonPatchDocument<UserForUpdateDto> userPatch)
        {
            if (!_userInfoRepository.UserExists(id))
            {
                return NotFound("User's Id does not exist");
            }
            if (!ModelState.IsValid || userPatch == null)
            {
                return BadRequest(ModelState);
            }
            
            var UserEntity = _userInfoRepository.GetUser(id, false);
            var UserToPatch = Mapper.Map<UserForUpdateDto>(UserEntity);
            userPatch.ApplyTo(UserToPatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TryValidateModel(UserToPatch);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Mapper.Map(UserToPatch, UserEntity);
            if (!_departmentInfoRepository.DepartmentExists(UserEntity.DepartmentAcronym))
            {
                return NotFound("Department Acronym does not exist");
            }
            if (!_userInfoRepository.SaveUser())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }
            bool RoleExists = await _roleManager.RoleExistsAsync(UserToPatch.Role);
            if (RoleExists)
            {
                var getCurrentRole = await _userManager.GetRolesAsync(UserEntity);
                var removeCurrentRoles = await _userManager.RemoveFromRolesAsync(UserEntity, getCurrentRole);
                var UpdateWithNewRole = await _userManager.AddToRoleAsync(UserEntity, UserToPatch.Role);
                if (!removeCurrentRoles.Succeeded && !UpdateWithNewRole.Succeeded)
                {
                    return StatusCode(500, "A problem happened while Updating User's Role request");
                }
            }
            else
            {
                return NotFound("Specified User's role to patch does not exists"); 
            }
            return NoContent();
        }
    }
}

