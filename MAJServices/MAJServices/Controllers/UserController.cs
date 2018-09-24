using AutoMapper;
using MAJServices.Entities;
using MAJServices.Models;
using MAJServices.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;

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

        //Get all Users
        [HttpGet()]
        public ActionResult GetUsers(bool includePosts = false)
        {
            var users = _userInfoRepository.GetUsers(includePosts);
            IEnumerable result;
            if(includePosts)
                result = Mapper.Map<IEnumerable<UserDto>>(users);
            else
                result = Mapper.Map<IEnumerable<UserWithoutPostsDto>>(users);
            return Ok(result);
        }

        //Get User
        [HttpGet("{id}" , Name = "GetUser")]
        public ActionResult GetUser(int id , bool includePosts = false)
        {
            var user = _userInfoRepository.GetUser(id, includePosts);
            object result = null;

            if (user == null)
                return NotFound();

            if (includePosts)
            {
                result = Mapper.Map<UserDto>(user);
            }
            else
            {
                result = Mapper.Map<UserWithoutPostsDto>(user);
            }
            return Ok(result);
        }


        [HttpPost("adduser")]
        public ActionResult AddUser( [FromBody]UserForCreationDto user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CreateUser = Mapper.Map<User>(user);
            _userInfoRepository.AddUser(CreateUser);
            if (!_userInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }
            var CreatedUser = Mapper.Map<UserWithoutPostsDto>(CreateUser);
            return CreatedAtRoute("GetUser", new { id = CreateUser.Id }, CreatedUser);
        }


    }
}
