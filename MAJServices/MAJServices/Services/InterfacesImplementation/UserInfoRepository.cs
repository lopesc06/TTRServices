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

        public void AddUserSubscription(UserSubscription subscription)
        {
            _infoContext.Subscriptions.Add(subscription);
        }

        public void DeleteUser(UserIdentity user)
        {
            var userToDelete = _infoContext.Users.Where(u => u.Id == user.Id).FirstOrDefault();
            userToDelete.isActive = false;
        }

        public void DeleteUserSubscription(UserSubscription subscription)
        {
            _infoContext.Subscriptions.RemoveRange(subscription);
        }

        public UserIdentity GetUser(string id, bool includePosts)
        {
            if (includePosts)
            {
                var user = _infoContext.Users.Include(u=>u.Posts).ThenInclude(p=>p.FilePaths)
                    .Where(u => u.Id == id)
                    //.OrderByDescending(p => p.Posts.OrderByDescending( pt=> pt.ReleaseDate).FirstOrDefault())
                    .FirstOrDefault();
            }
            return _infoContext.Users.Where(u => u.Id == id).FirstOrDefault();
        }
        
        public IEnumerable<UserIdentity> GetUsers(bool IncludePosts,string department)
        {
            if (IncludePosts)
            {

               return _infoContext.Users.Include(u => u.Posts).ThenInclude(p => p.FilePaths)
                    .OrderBy( u => u.Name).ThenBy( u => u.LastName)
                    .Where(u => u.DepartmentAcronym.Contains(department) && u.isActive)
                    //.ThenByDescending(p => p.Posts.OrderByDescending(pt => pt.ReleaseDate).FirstOrDefault())
                    .ToList();
            }
            return _infoContext.Users.OrderBy(u => u.Name).ThenBy(u => u.LastName)
                               .Where(u => u.DepartmentAcronym.Contains(department) && u.isActive)
                               .ToList();
        }

        public IEnumerable<UserSubscription> GetUserSubscription(string id)
        {
            return _infoContext.Subscriptions.Where(u => u.UserId == id).ToList();
        }

        public bool SaveUser()
        {
            return (_infoContext.SaveChanges() >= 0);
        }

        public bool UserExists(string Id)
        {
            return _infoContext.Users.Any(u => u.Id == Id && u.isActive == true);
        }
        
    }
}
