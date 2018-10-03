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
        
        public UserController(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
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
//------------------------------------Full update of user---------------------------------------//
        [HttpPut("userupdate/{id}")]
        public ActionResult UserUpdate(string id, [FromBody]UserForUpdateDto userUpdate)
        {
            if (!_userInfoRepository.UserExist(id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid || userUpdate == null)
            {
                return BadRequest(ModelState);
            }
            var UserEntity = _userInfoRepository.GetUser(id, false);
            if (UserEntity == null)
            {
                return NotFound();
            }
            Mapper.Map(userUpdate, UserEntity);
            if (!_userInfoRepository.SaveUser())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }
            return NoContent();
        }

//----------------------------------------Partial User Update----------------------------//
        [HttpPatch("userupdate/{id}")]
        public ActionResult PartialUserUpdate(string id, [FromBody]JsonPatchDocument<UserForUpdateDto> userPatch)
        {
            if (!_userInfoRepository.UserExist(id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid || userPatch == null)
            {
                return BadRequest(ModelState);
            }
            var UserEntity = _userInfoRepository.GetUser(id, false);
            if (UserEntity == null)
            {
                return NotFound();
            }
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

            if (!_userInfoRepository.SaveUser())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }
            return NoContent();
        }
    }
}

