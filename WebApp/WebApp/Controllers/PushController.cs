using System;
using System.Collections.Specialized;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace PushSender.Controllers
{
    [Route("api/[controller]")]
    public class PushController : Controller
    {

        [HttpPost]
        public void Post(string appToken, string userKey, string message)
        {
            var parameters = new NameValueCollection {
                { "token", appToken },
                { "user", userKey },
                { "message", message }
            };
            using (var client = new WebClient())
            {
                try
                {
                    client.UploadValues("https://api.pushover.net/1/messages.json", parameters);
                }
                catch (WebException)
                {
                    //обработать ошибку 404
                }
            }
        }
    }
}