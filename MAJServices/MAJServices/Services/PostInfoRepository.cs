using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAJServices.Entities;

namespace MAJServices.Services
{
    public class PostInfoRepository : IPostInfoRepository
    {
        private InfoContext _infoContext;
        public PostInfoRepository(InfoContext infoContext)
        {
            _infoContext = infoContext;
        }

        public User GetUser(int id, bool includePosts)
        {
            return _infoContext.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public void AddUserPost(int id, Post post)
        {
            var user = GetUser(id, false);
            user.Posts.Add(post);
        }

        public Post GetUserPost(int idUser, int idPost)
        {
            return _infoContext.Posts.Where(p => p.UserId == idUser && p.Id == idPost).FirstOrDefault();
        }

        public void DeleteUserPost(Post post)
        {
            _infoContext.Posts.Remove(post);
        }

        public bool SavePost()
        {
            return (_infoContext.SaveChanges() >= 0);
        }

    }
}
