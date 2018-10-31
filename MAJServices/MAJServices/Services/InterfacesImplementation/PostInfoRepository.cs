﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAJServices.Entities;
using Microsoft.EntityFrameworkCore;

namespace MAJServices.Services
{
    public class PostInfoRepository : IPostInfoRepository
    {
        private InfoContext _infoContext;
        public PostInfoRepository(InfoContext infoContext)
        {
            _infoContext = infoContext;
        }

        private UserIdentity GetUser(string id, bool includePosts)
        {
            return _infoContext.Users.Where(u => u.Id == id.ToString()).FirstOrDefault();
        }

        public void AddUserPost(string id, Post post)
        {
            var user = GetUser(id, false);
            user.Posts.Add(post);
        }

        public IEnumerable<Post> GetRecentPosts(string dpt)
        {
            var Today = DateTime.Today;
            var Limitday = Today.Day == 31 ? 30 : Today.Day; 
            var Limit = new DateTime(Today.Year, Today.Month - 1,Limitday);
            var res = _infoContext.Posts.Include(p => p.Publisher).Include(p => p.FilePaths)
                .Where(p => p.ReleaseDate <= Today && p.ReleaseDate >= Limit && p.Publisher.DepartmentAcronym.Contains(dpt))
                .OrderByDescending(p => p.ReleaseDate).ToList();
            return res;
        }

        public Post GetUserPost(string idUser, int idPost)
        {
            return _infoContext.Posts.Include(p=>p.FilePaths)
                    .Where(p => p.UserId == idUser.ToString() && p.Id == idPost).FirstOrDefault();
        }

        public void DeleteUserPost(Post post)
        {
            _infoContext.Posts.Remove(post);
        }

        public bool SavePost()
        {
            return (_infoContext.SaveChanges() >= 0);
        }

        public bool PostExists(string idUser, int idPost)
        {
            return _infoContext.Posts.Any(p => p.Id == idPost && p.UserId == idUser);
        }
    }
}
