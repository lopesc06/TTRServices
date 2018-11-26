using AutoMapper;
using MAJServices.Entities;
using MAJServices.Models;
using MAJServices.Models.FirebaseCM;
using MAJServices.Services;
using MAJServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
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

        [HttpGet("fcm/sendpush")]
        public async Task<bool> SendPushNotification()
        {
            var applicationID = Environment.GetEnvironmentVariable("FirebaseServerKey");
            var senderId = Environment.GetEnvironmentVariable("FirebaseSenderID");
            var destination = "/topics/"+"CATT";

            using (var client = new HttpClient())
            {
                //do something with http client
                client.BaseAddress = new Uri("https://fcm.googleapis.com");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"key={applicationID}");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Sender", $"id={senderId}");
                var data = new
                {
                    to = destination,
                    data = new
                    {
                        body = "Este es un body mediante data",
                        title = "Este es un title mediante data ",
                        extra = "Este es un campo extra mediante data"
                    },
                    priority = "high"
                };
                var json = JsonConvert.SerializeObject(data);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/fcm/send", httpContent);
            }
            return true;
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

            var entityResult = _firebaseInfoRepository.GetUserDevice(FCMForCreationDto.UserId, FCMForCreationDto.DeviceId);
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
            _firebaseInfoRepository.SaveToken();
            return Ok();
        }

    }
}
