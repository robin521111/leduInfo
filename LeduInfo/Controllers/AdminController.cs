using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Configuration;
using LeduInfo.Models;
using System.Web.Security;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LeduInfo.Controllers
{
    public class AdminController : Controller
    {



        #region Common parameter initialize

        protected string url = "https://worktile.com/api/projects/f99907c89edd4c068abd92a1190c9594/tasks/exports?format=json";
        AccountDB DB = new AccountDB();


        #endregion//
        // GET: /Admin/

        public ActionResult Admin(string userId)
        {
            var user = Membership.GetUser();
            ViewBag.name = user.UserName;
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult DashBoard()
        {

            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        
        

        #region Worktile Data sync



        //public ActionResult TaskSync()
        //{
        //    WebClient wc = new WebClient();
        //    var result = JsonConvert.DeserializeObject(wc.DownloadString(url));

        //    return View(result);

        //    //using (var client = new HttpClient())
        //    //{

        //    //    client.BaseAddress = new Uri("https://worktile.com");
        //    //    client.DefaultRequestHeaders.Accept.Clear();
        //    //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    //    HttpResponseMessage message = client.GetAsync(@"api/projects/f99907c89edd4c068abd92a1190c9594/tasks").Result;


        //    //    HttpContent content = message.Content;

        //    //}



        //    //var json=new WebClient().DownloadString("https://worktile.com/api/projects/f99907c89edd4c068abd92a1190c9594/tasks/exports?format=json");

        //    //JsonTextReader reader = new JsonTextReader(new StringReader(json));
        //    //while (reader.Read())
        //    //{
        //    //    if (reader.Value !=null)
        //    //    {
        //    //        Response.Write(reader.Value);
        //    //    }
        //    //    else
        //    //    {
        //    //        Response.Write(reader.TokenType);
        //    //    }
        //    //}

        //    //var serializeJson = JsonConvert.DeserializeObject(json);


        //}



        #endregion

    }
}
