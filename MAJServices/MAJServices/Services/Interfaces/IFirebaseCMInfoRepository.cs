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
        FirebaseCM GetUserDevice(string deviceId);
        IEnumerable<string> GetUserTokensDevices(List<string> usersId);
        void AddTokenToDeviceId(FirebaseCM userDevice);
        bool SaveToken();
    }
}
