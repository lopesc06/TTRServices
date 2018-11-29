using MAJServices.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MAJServices.Helpers
{
    public static class PushNotification
    {
        public static async Task SendPush(PostWithoutUserDto post,string department)
        {
            var applicationID = Environment.GetEnvironmentVariable("FirebaseServerKey");
            var senderId = Environment.GetEnvironmentVariable("FirebaseSenderID");
            var destination = "/topics/" + department.ToUpper();
            using (var client = new HttpClient())
            {
                //do something with http client
                client.BaseAddress = new Uri("https://fcm.googleapis.com");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"key={applicationID}");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Sender", $"id={senderId}");
                var FcmMessage = new
                {
                    to = destination,
                    notification = new
                    {
                        body = post.Description,
                        title = department + ":" + post.Title
                    },
                    data = new
                    {
                        notif_body = post.Description,
                        notif_title = department + ":" + post.Title,
                        type = "notification",
                        department = department.ToUpper(),
                        trigger = "posting"
                    },
                    priority = "normal"
                };
                var FcmMessage2 = new
                {
                    to = destination,
                    data = new
                    {
                        notif_body = post.Description,
                        notif_title = department + ":" + post.Title,
                        type = "data",
                        department = department.ToUpper(),
                        trigger = "posting"
                    },
                    priority = "normal"
                };
                var json1 = JsonConvert.SerializeObject(FcmMessage);
                var json2 = JsonConvert.SerializeObject(FcmMessage2);
                var httpContent = new StringContent(json1, Encoding.UTF8, "application/json");
                await client.PostAsync("/fcm/send", httpContent);
                httpContent = new StringContent(json2, Encoding.UTF8, "application/json");
                await client.PostAsync("/fcm/send", httpContent);
            }
        }
    }
}
