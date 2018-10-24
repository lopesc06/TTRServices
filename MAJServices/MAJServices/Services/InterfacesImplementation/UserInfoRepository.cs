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
        
        public void AddUser(UserIdentity user)
        {
            _infoContext.Users.Add(user);
        }
        
        public void DeleteUser(UserIdentity user)
        {
            _infoContext.Users.Remove(user);
        }
        
        public UserIdentity GetUser(string id, bool includePosts)
        {
            if (includePosts)
            {
                var user = _infoContext.Users.Include(u=>u.Posts).ThenInclude(p=>p.FilePaths)
                    .Where(u => u.Id == id).FirstOrDefault();
            }
            return _infoContext.Users.Where(u => u.Id == id).FirstOrDefault();
        }
        
        public IEnumerable<UserIdentity> GetUsers(bool IncludePosts)
        {
            if (IncludePosts)
            {

               return _infoContext.Users.Include(u => u.Posts).ThenInclude(p => p.FilePaths)
                    .OrderBy( u => u.Name).ThenBy( u => u.LastName).ToList();
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
