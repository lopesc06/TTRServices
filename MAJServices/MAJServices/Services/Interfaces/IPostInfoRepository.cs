using MAJServices.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Services
{
    public interface IPostInfoRepository
    {
        void AddUserPost(string id, Post post);
        Post GetUserPost(string idUser, int idPost);
        IEnumerable<Post> GetRecentPosts();
        void DeleteUserPost(Post post);
        bool PostExist(string idUser, int idPost);
        bool SavePost();
    }
}
