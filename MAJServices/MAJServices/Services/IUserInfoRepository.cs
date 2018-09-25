using MAJServices.Entities;
using System;
using System.Collections.Generic;

namespace MAJServices.Services
{
    public interface IUserInfoRepository
    {
        void AddUser(User user);
        void DeleteUser(User user);
        bool UserExist(int id);
        User GetUser(int Id, bool includePosts);
        IEnumerable<User> GetUsers(bool includePosts);
        bool SaveUser();
    }
}
