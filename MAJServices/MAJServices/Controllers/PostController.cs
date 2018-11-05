using AutoMapper;
using MAJServices.Entities;
using MAJServices.Helpers;
using MAJServices.Models;
using MAJServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Controllers
{

    [Route("api/users")]
    public class PostController : Controller
    {
        private IPostInfoRepository _postInfoRepository;
        private readonly IUserInfoRepository _userInfoRepository;
        public PostController(IPostInfoRepository postInfoRepository, IUserInfoRepository userInfoRepository)
        {
            _postInfoRepository = postInfoRepository;
            _userInfoRepository = userInfoRepository;
        }

//-------------------------Get all Posts from last month-----------------------------------------//
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("post")]
        public IActionResult GetLastPosts(string dpt="")
        {
            var recentPostsEntity = _postInfoRepository.GetRecentPosts(dpt);
            var postsDtoResult = Mapper.Map<List<PostDto>>(recentPostsEntity);
            foreach(PostDto postDto in postsDtoResult)
            {
                var p = _postInfoRepository.GetUserPost(postDto.Publisher.Id, postDto.Id);
                postDto.FilePaths = Mapper.Map<List<FilePathDto>>(p.FilePaths);
            }
            return Ok(postsDtoResult);
        }

//-------------------------Get a post from a user-----------------------------------------//
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Publishers")]
        [HttpGet("{iduser}/post/{idPost}", Name ="GetUserPost")]
        public IActionResult GetUserPost(string idUser, int idPost){
            if (!_postInfoRepository.PostExists(idUser, idPost))
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
        public async Task<IActionResult> AddUserPostAsync(string idUser, [FromBody]PostForCreationDto postForCreationDto)
        {
            var publisher = _userInfoRepository.GetUser(idUser,false);
            if (publisher == null)
            {
                return NotFound();
            }
            if (postForCreationDto == null || !ModelState.IsValid)
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
            await PushNotification.SendPush(CreatedPost,publisher.DepartmentAcronym);
            return CreatedAtRoute("GetUserPost", new { idUser, idPost = CreatePost.Id }, CreatedPost);
        }
        
//-------------------------Delete post from a user-----------------------------------------//
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Publishers")]
        [HttpDelete("{iduser}/post/{idpost}")]
        public IActionResult DeleteUserPost(string idUser, int idPost)
        {
            if (!_postInfoRepository.PostExists(idUser, idPost))
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
        public IActionResult PatchUserPost(string idUser , int idPost , [FromBody]JsonPatchDocument<PostForUpdateDto> postPatch) 
        {
            if (!_postInfoRepository.PostExists(idUser,idPost))
            {
                return NotFound();
            }
            if (!ModelState.IsValid || postPatch == null){
                return BadRequest(ModelState);
            }
            var PostEntity = _postInfoRepository.GetUserPost(idUser, idPost);
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
