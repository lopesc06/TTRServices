using System;
using MAJServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace MAJServices.Controllers
{
    [Route("api/users/posts")]
    public class PostController : Controller
    {
        private IUserInfoRepository _userInfoRepository;
        public PostController(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }


        [HttpGet("{id}")]
        public GetUserPost(int id ){


        }

    }
}
