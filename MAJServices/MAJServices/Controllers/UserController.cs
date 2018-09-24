using AutoMapper;
using MAJServices.Entities;
using MAJServices.Models;
using MAJServices.Services;
using Microsoft.AspNetCore.JsonPatch;
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

        //Get all Users with or without users' posts
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

        //Get User with or without user's posts
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

        //add a new user 
        [HttpPost("adduser")]
        public ActionResult AddUser( [FromBody]UserForCreationDto userDto)
        {
            if(userDto == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CreateUser = Mapper.Map<User>(userDto);
            _userInfoRepository.AddUser(CreateUser);
            if (!_userInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }
            var CreatedUser = Mapper.Map<UserWithoutPostsDto>(CreateUser);
            return CreatedAtRoute("GetUser", new { id = CreateUser.Id }, CreatedUser);
        }

        //Full update of user
        [HttpPut("userupdate/{id}")]
        public ActionResult UserUpdate ( int id , [FromBody]UserForUpdateDto userUpdate){
            if(!_userInfoRepository.UserExist(id)){
                return NotFound();
            }
            if(!ModelState.IsValid || userUpdate == null){
                return BadRequest(ModelState);
            }
            var UserEntity = _userInfoRepository.GetUser(id,false);
            if(UserEntity == null){
                return NotFound();
            }
            Mapper.Map(userUpdate, UserEntity);
            if(!_userInfoRepository.Save()){
                return StatusCode(500, "A problem happened while handling your request");
            }
            return NoContent();
        }

        //Partial User Update
        [HttpPatch("userupdate/{id}")]
        public ActionResult PartialUserUpdate( int id , [FromBody]JsonPatchDocument<UserForUpdateDto> userPatch){
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
            var UserToPatch = Mapper.Map<UserForUpdateDto>(userPatch);
            userPatch.ApplyTo(UserToPatch,ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TryValidateModel(UserToPatch);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Mapper.Map(UserToPatch, UserEntity);

            if (!_userInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }
            return NoContent();
        }

        //Delete User
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id){
            if(!_userInfoRepository.UserExist(id)){
                return NotFound();
            }
            var UserEntity = _userInfoRepository.GetUser(id,false);
            if(UserEntity == null){
                return NotFound();
            }
            _userInfoRepository.DeleteUser(UserEntity);

            if (!_userInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }
            return NoContent();
        }
    }
}
