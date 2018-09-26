using MAJServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Services
{
    public interface IPostInfoRepository
    {
        void AddUserPost(int id, Post post);
        Post GetUserPost(int idUser, int idPost);
        void DeleteUserPost(Post post);
        bool PostExist(int idPost);
        bool SavePost();
    }
}
