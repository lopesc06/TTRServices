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

        public User GetUser(string id, bool includePosts)
        {

            return _infoContext.Users.Where(u => u.Id == id.ToString()).FirstOrDefault();
        }

        public void AddUserPost(string id, Post post)
        {
            var user = GetUser(id, false);
            user.Posts.Add(post);
        }

        public Post GetUserPost(string idUser, int idPost)
        {
            return _infoContext.Posts.Where(p => p.UserId == idUser.ToString() && p.Id == idPost).FirstOrDefault();
        }

        public void DeleteUserPost(Post post)
        {
            _infoContext.Posts.Remove(post);
        }

        public bool SavePost()
        {
            return (_infoContext.SaveChanges() >= 0);
        }

        public bool PostExist(int idPost)
        {
            return _infoContext.Posts.Any(p => p.Id == idPost);
        }
    }
}
