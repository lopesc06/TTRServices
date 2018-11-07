using MAJServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Services.Interfaces
{
    public interface IFirebaseCMInfoRepository
    {
        bool UserExists(string userId);
        FirebaseCM GetUserDevice(string userId, string deviceId);
        void AddTokenToDeviceId(FirebaseCM userDevice);
        bool SaveToken();
    }
}
