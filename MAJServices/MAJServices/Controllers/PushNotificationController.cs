using MAJServices.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MAJServices.Controllers
{
    [Route("api/push")]
    public class PushNotificationController
    {
        [Route("send")]
        public async Task<bool> SendPushNotification(PostWithoutUserDto post,string topic = null )
        {
            var applicationID = Environment.GetEnvironmentVariable("FirebaseServerKey");
            var senderId = Environment.GetEnvironmentVariable("FirebaseSenderID");
            var destination = "/topics/"+topic;

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
                    notification = new
                    {
                        body = "Este es un mensaje de prueba "+topic ,
                        title = "notificacion para los interesados de "+topic ,
                        icon = "myicon",
                        color = "#FFC300"
                    },
                    priority = "high"

                };
                var json = JsonConvert.SerializeObject(data);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/fcm/send", httpContent);
            }
            return true;
        }
    }
}
