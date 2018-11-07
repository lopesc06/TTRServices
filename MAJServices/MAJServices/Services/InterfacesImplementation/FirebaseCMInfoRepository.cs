﻿using MAJServices.Entities;
using MAJServices.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Services.InterfacesImplementation
{
    public class FirebaseCMInfoRepository : IFirebaseCMInfoRepository
    {
        private InfoContext _infoContext;

        public FirebaseCMInfoRepository(InfoContext infoContext)
        {
            _infoContext = infoContext;
        }

        public void AddTokenToDeviceId(FirebaseCM userDevice)
        {
            _infoContext.FirebaseCMDevices.Add(userDevice);
        }

        public FirebaseCM GetUserDevice(string userId, string deviceId)
        {
            return _infoContext.FirebaseCMDevices
                .Where(fcm => fcm.UserId == userId && fcm.DeviceId == deviceId).FirstOrDefault();
        }

        public bool SaveToken()
        {
            return (_infoContext.SaveChanges() >= 0);
        }

        public bool UserExists(string userId)
        {
            return _infoContext.Users.Any(u => u.Id == userId);
        }
    }
}