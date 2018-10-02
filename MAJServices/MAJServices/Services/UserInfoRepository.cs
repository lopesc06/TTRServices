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
        
        public void DeleteUser(User user)
        {
            _infoContext.Users.Remove(user);
        }
        
        public User GetUser(string id, bool includePosts)
        {
            if (includePosts)
            {
                return _infoContext.Users.Include(p=>p.Posts).Where(u => u.Id == id).FirstOrDefault();
            }
            return _infoContext.Users.Where(u => u.Id == id).FirstOrDefault();
        }
        
        public IEnumerable<User> GetUsers(bool IncludePosts)
        {
            if (IncludePosts)
            {
                return _infoContext.Users.Include(u => u.Posts).OrderBy( u => u.Name).ThenBy( u => u.LastName).ToList();
            }
            return _infoContext.Users.OrderBy(u => u.Name).ThenBy(u => u.LastName).ToList();
        }

        public bool SaveUser()
        {
            return (_infoContext.SaveChanges() >= 0);
        }

        public bool UserExist(string Id)
        {
            return _infoContext.Users.Any(u => u.Id == Id);
        }
        
    }
}
