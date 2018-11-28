using AutoMapper;
using MAJServices.Entities;
using MAJServices.Models;
using MAJServices.Models.FirebaseCM;
using MAJServices.Services;
using MAJServices.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MAJServices.Controllers
{
    [Route("api/users")]
    public class PushNotificationController : Controller
    {
        private IFirebaseCMInfoRepository _firebaseInfoRepository;

        public PushNotificationController(IFirebaseCMInfoRepository firebaseInfoRepository)
        {
            _firebaseInfoRepository = firebaseInfoRepository;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Publishers")]
        [HttpPost("fcm/sendpush")]
        public async Task SendPushNotification([FromBody]IEnumerable<NotificationForCreationDto> notifications)
        {
            var userId = User.FindFirst("username").Value;
            if (!_firebaseInfoRepository.UserExists(userId))
            {
                return;
            }
            var publisher = User.FindFirst("department").Value.ToUpper();
            var applicationID = Environment.GetEnvironmentVariable("FirebaseServerKey");
            var senderId = Environment.GetEnvironmentVariable("FirebaseSenderID");
            string message = "", title= "";
            List<string> usersId = new List<string>();
            using (var client = new HttpClient())
            {
                //do something with http client
                client.BaseAddress = new Uri("https://fcm.googleapis.com");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"key={applicationID}");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Sender", $"id={senderId}");
                foreach(NotificationForCreationDto n in notifications)
                {
                    title = n.Title;
                    message = n.Message;
                    usersId.Add(n.UserId);
                }
                var userDevices = _firebaseInfoRepository.GetUserTokensDevices(usersId);
                foreach (string Token in userDevices)
                {
                    var data = new
                    {
                        to = Token,
                        notification = new
                        {
                            body = message,
                            title
                        },
                        data = new {
                            department = publisher,
                            trigger = "notifyuser"
                        },
                        priority = "high"
                    };
                    var json = JsonConvert.SerializeObject(data);
                    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                    await client.PostAsync("/fcm/send", httpContent);
                }
            }
        }

        [HttpPost("fcm/token")]
        public IActionResult AddTokenToDevice([FromBody]FirebaseCMForCreationDto FCMForCreationDto)
        {
            if (FCMForCreationDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_firebaseInfoRepository.UserExists(FCMForCreationDto.UserId))
            {
                return NotFound("UserId not found");
            }

            var entityResult = _firebaseInfoRepository.GetUserDevice(FCMForCreationDto.DeviceId);
            if (entityResult == null )
            {
                var FCMEntity = Mapper.Map<FirebaseCM>(FCMForCreationDto);
                _firebaseInfoRepository.AddTokenToDeviceId(FCMEntity);
                if (!_firebaseInfoRepository.SaveToken())
                {
                    return StatusCode(500, "A problem happened while handling your request");
                }
                return Ok();
            }
            entityResult.Token = FCMForCreationDto.Token;
            entityResult.UserId = FCMForCreationDto.UserId;
            _firebaseInfoRepository.SaveToken();
            return Ok();
        }

    }
}
