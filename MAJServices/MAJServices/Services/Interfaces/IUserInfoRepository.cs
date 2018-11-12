using MAJServices.Entities;
using System;
using System.Collections.Generic;

namespace MAJServices.Services
{
    public interface IUserInfoRepository
    {
        void AddUser(UserIdentity user);
        void AddUserSubscription(UserSubscription subscription);
        IEnumerable<UserSubscription> GetUserSubscription(string id);
        void DeleteUserSubscription(UserSubscription subscription);
        void DeleteUser(UserIdentity user);
        bool UserExists(string id);
        UserIdentity GetUser(string Id, bool includePosts);
        IEnumerable<UserIdentity> GetUsers(bool includePosts, string department);
        bool SaveUser();
    }
}
