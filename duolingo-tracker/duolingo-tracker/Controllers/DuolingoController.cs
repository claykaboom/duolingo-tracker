using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using duolingo_tracker.Models;
using Newtonsoft.Json.Linq;

namespace duolingo_tracker.Controllers
{
    public class DuolingoController : Controller
    {
        public JsonResult Login(string userName, string password)
        { 

            var requestUri = ("https://www.duolingo.com/login");
            string postData = string.Format("{{login: \"{0}\", password:\"{1}\"}}", userName, password);
            HttpClient client = new HttpClient() { MaxResponseContentBufferSize = 1000000 };

            string name = "";
            Task<HttpResponseMessage> webText = new Task<HttpResponseMessage>(() =>
            {


                StringContent stringContent = new StringContent(postData);
                var ret = client.PostAsync(requestUri, stringContent).Result;
                name = ret.Content.ReadAsStringAsync().Result;
                return ret;

            });

            webText.RunSynchronously();

            return Json(new { name = userName }, JsonRequestBehavior.AllowGet);
 
        }

        public JsonResult GetUserInfo(string userName)
        {
 
            HttpClient client = new HttpClient() { MaxResponseContentBufferSize = 1000000 };

            var requestUri = "https://www.duolingo.com/users/" + userName;
            DuolingoUser user = null;
            Task<string> getStringTask = new Task<string>(() =>
            {
                var taskResult = client.GetStringAsync(requestUri).Result;

                user = JObject.Parse(taskResult).ToObject<DuolingoUser>();
                //site_streak
                return taskResult;

            });
            getStringTask.RunSynchronously();

            return Json(user, JsonRequestBehavior.AllowGet);

        }
	}
}