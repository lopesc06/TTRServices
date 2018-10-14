using AutoMapper;
using MAJServices.Entities;
using MAJServices.Models;
using MAJServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MAJServices.Controllers
{

    [Route("api/users")]
    public class PostController : Controller
    {
        private IPostInfoRepository _postInfoRepository;
        private IUserInfoRepository _userInfoRepository;
        public PostController(IPostInfoRepository postInfoRepository , IUserInfoRepository userInfoRepository)
        {
            _postInfoRepository = postInfoRepository;
            _userInfoRepository = userInfoRepository;
        }

//-------------------------Get all Posts from last month-----------------------------------------//
        [HttpGet("post")]
        public IActionResult GetLastPosts()
        {
            var RecentPosts = _postInfoRepository.GetRecentPosts();
            var PostsResult = Mapper.Map<List<PostDto>>(RecentPosts);
            return Ok(PostsResult);
        }

//-------------------------Get a post from a user-----------------------------------------//
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Publishers")]
        [HttpGet("{iduser}/post/{idPost}", Name ="GetUserPost")]
        public IActionResult GetUserPost(string idUser, int idPost){
            if (!_userInfoRepository.UserExist(idUser))
            {
                return NotFound();
            }
            var UserPost = _postInfoRepository.GetUserPost(idUser, idPost);
            var result = Mapper.Map<PostWithoutUserDto>(UserPost);
            if(UserPost == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

//-------------------------Add post from a user-----------------------------------------//
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Publishers")]
        [HttpPost("{iduser}/post")]
        public IActionResult AddUserPost(string idUser, [FromBody]PostForCreationDto postForCreationDto)
        {
            if (!_userInfoRepository.UserExist(idUser))
            {
                return NotFound();
            }
            if (postForCreationDto == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var CreatePost = Mapper.Map<Post>(postForCreationDto);
            _postInfoRepository.AddUserPost(idUser, CreatePost);

            if (!_postInfoRepository.SavePost())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }
            var CreatedPost = Mapper.Map<PostWithoutUserDto>(CreatePost);
            //await new PushNotificationController().SendPushNotification(CreatedPost);
            return CreatedAtRoute("GetUserPost", new { idUser = idUser, idPost = CreatePost.Id }, CreatedPost);
        }
        
//-------------------------Delete post from a user-----------------------------------------//
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Publishers")]
        [HttpDelete("{iduser}/post/{idpost}")]
        public IActionResult DeleteUserPost(string idUser, int idPost)
        {
            if (!_userInfoRepository.UserExist(idUser))
            {
                return NotFound();
            }
            var PostEntity = _postInfoRepository.GetUserPost(idUser, idPost);
            if(PostEntity == null)
            {
                return NotFound();
            }
            _postInfoRepository.DeleteUserPost(PostEntity);
            if (!_postInfoRepository.SavePost())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }
            return NoContent();
        }

//-------------------------patch a user's post-----------------------------------------//
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Publishers")]
        [HttpPatch("{iduser}/post/{idpost}")]
        public IActionResult PatchUserPost(string iduser , int idpost , [FromBody]JsonPatchDocument<PostForUpdateDto> postPatch) 
        {
            if (!_userInfoRepository.UserExist(iduser) || !_postInfoRepository.PostExist(idpost))
            {
                return NotFound();
            }
            if (!ModelState.IsValid || postPatch == null){
                return BadRequest(ModelState);
            }
            var PostEntity = _postInfoRepository.GetUserPost(iduser, idpost);
            if (PostEntity == null)
            {
                return NotFound();
            }
            var PostToPatch = Mapper.Map<PostForUpdateDto>(PostEntity);
            postPatch.ApplyTo(PostToPatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TryValidateModel(PostToPatch);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Mapper.Map(PostToPatch, PostEntity);
            if (!_postInfoRepository.SavePost())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }
            return NoContent();
        }

    }
}
