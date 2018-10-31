using MAJServices.Entities;
using System;
using System.Collections.Generic;

namespace MAJServices.Services
{
    public interface IUserInfoRepository
    {
        void AddUser(UserIdentity user);
        void DeleteUser(UserIdentity user);
        bool UserExists(string id);
        UserIdentity GetUser(string Id, bool includePosts);
        IEnumerable<UserIdentity> GetUsers(bool includePosts);
        bool SaveUser();
    }
}
