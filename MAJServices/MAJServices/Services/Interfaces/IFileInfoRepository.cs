using MAJServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Services.Interfaces
{
    public interface IFileInfoRepository
    {
        void AddFileToPost(FilePath file);
        void AddFileToUser(FilePath file);
        bool SaveFile();
        Post RetrievePost(int idPost);
        UserIdentity RetrieveUser(string idUser);
        void ClearPreviousFiles(int idPost);
    }
}
