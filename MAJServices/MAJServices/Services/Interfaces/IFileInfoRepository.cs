using MAJServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Services.Interfaces
{
    public interface IFileInfoRepository
    {
        void AddFile(FilePath file);
    }
}
