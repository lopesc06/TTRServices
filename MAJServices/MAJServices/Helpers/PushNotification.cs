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
                var data = new
                {
                    to = destination,
                    notification = new
                    {
                        body = post.Description,
                        title =department+":"+post.Title,
                       // icon = "myicon",
                       // color = "#FFC300"
                    },
                    priority = "normal"
                };
                var json = JsonConvert.SerializeObject(data);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/fcm/send", httpContent);
            }
        }
    }
}
