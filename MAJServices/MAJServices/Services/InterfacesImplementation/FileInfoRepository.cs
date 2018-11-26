using MAJServices.Entities;
using MAJServices.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Services.InterfacesImplementation
{
    public class FileInfoRepository : IFileInfoRepository
    {
        private InfoContext _infoContext;

        public FileInfoRepository(InfoContext infoContext)
        {
            _infoContext = infoContext;
        }

        public void AddFileToPost(FilePath file)
        {
            _infoContext.FilePaths.Add(file);
        }

        UserIdentity IFileInfoRepository.RetrieveUser(string idUser)
        {
            return _infoContext.Users.FirstOrDefault(u => u.Id == idUser);
        }

        public bool SaveFile()
        {
            return (_infoContext.SaveChanges() >= 0);
        }

        public Post RetrievePost(int idPost)
        {
            return _infoContext.Posts.FirstOrDefault(p => p.Id == idPost);
        }

        public void ClearPreviousFiles(int idPost)
        {
            var filesToRemove = _infoContext.FilePaths.Where(f => f.PostId == idPost);
            _infoContext.FilePaths.RemoveRange(filesToRemove);
        }

        public void AddFileToUser(FilePath file)
        {
            throw new NotImplementedException();
        }
        
    }
}
