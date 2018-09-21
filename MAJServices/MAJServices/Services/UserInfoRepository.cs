using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAJServices.Entities;
using Microsoft.EntityFrameworkCore;

namespace MAJServices.Services
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private InfoContext _infoContext;
        public UserInfoRepository(InfoContext infoContext)
        {
            _infoContext = infoContext;
        }
        
        public void AddUser(User user)
        {
            _infoContext.Users.Add(user);
        }

        public void AddUserPost(int Id, Post post)
        {
            var user = GetUser(Id, false);
            user.Posts.Add(post);
        }

        public void DeleteUser(User user)
        {
            _infoContext.Users.Remove(user);
        }

        public void DeleteUserPost(Post post)
        {
            _infoContext.Posts.Remove(post);
        }

        public User GetUser(int Id, bool IncludePosts)
        {
            if (IncludePosts)
            {
                return _infoContext.Users.Include( u => u.Posts).Where(u => u.Id == Id).FirstOrDefault();
            }
            return _infoContext.Users.Where(u => u.Id == Id).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers(bool IncludePosts)
        {
            if (IncludePosts)
            {
                return _infoContext.Users.Include(u => u.Posts).OrderBy( u => u.Name).ThenBy( u => u.LastName).ToList();
            }
            return _infoContext.Users.OrderBy(u => u.Name).ThenBy(u => u.LastName).ToList();
        }

        public bool Save()
        {
            return (_infoContext.SaveChanges() >= 0);
        }

        public bool UserExist(int Id)
        {
            return _infoContext.Users.Any(u => u.Id == Id);
        }
        
    }
}
