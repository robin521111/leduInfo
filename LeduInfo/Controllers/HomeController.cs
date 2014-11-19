using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeduInfo.Models;
using Infrustructure;
using System.Security;

namespace LeduInfo.Controllers
{
    public class HomeController : Controller
    {
        leduInfoDB DB = new leduInfoDB();
        Infrustructure.Blog.MicroBlog microblog = new Infrustructure.Blog.MicroBlog();
        Image image = new Image();

        public ActionResult Index(string userName = "")
        {
            
           // FileModel fileModel = new FileModel();
           // fileModel.SaveFilePath();
            
            ViewBag.Message = userName;

            //fileModel.FilePaths = DB.FileResourcetbl.Select(f => f.Path).ToList();

            return View();
        }
        /// action for About view
        /// 
        public ActionResult About()
        {
            ViewBag.Message = "Your quintessential app description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your quintessential contact page.";

            return View();
        }

        public ActionResult LeduIndex()
        {
            ViewBag.Message = "Your Info system for renting.";
            return View();
        }

        public ActionResult InfoPage()
        {
            ViewBag.Message = "This is the info page for user to search!";
            return View();
        }
        public ActionResult Charts()
        {
            ViewBag.Charts = " This is a Chart for demo ";
            return View();
        }

        public ActionResult Vote()
        {
            ViewBag.Message = "Vote for your topic!";
            return View();
        }
        public ActionResult CommunityDesigner()
        {
            SilverlightObject uploadControl = new SilverlightObject
            {
                XapName = "CommunityDesigner",
                Size=new System.Drawing.Size(800,800)
            };
            UploadViewModel model = new UploadViewModel()
            {
                UploadControl = uploadControl
            };
            return View(model);
        }

        public ActionResult JsonUploader()
        {
            SilverlightObject JsonUploaderControl = new SilverlightObject
            {
                XapName = "JsonUploader",
                Size = new System.Drawing.Size(500, 600)
            };

            JsonUploadModel model = new JsonUploadModel()
            {
                JsonUploadControl=JsonUploaderControl
            };
        
            return View(model);
        }

        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult RnD()
        {

            return View();
        }

        

        public ActionResult Redirect()
        {
            Response.RedirectToRoute("Default");
            return View();
        }

        public ActionResult AboutMe()
        {
            return View();
        }

        public ActionResult Services()
        {
            var image1 = DB.FileResourcetbl.Find(1);
            var image = (from p in DB.FileResourcetbl
                         orderby p.FileTypeID
                         select p.Path).Take(1);
            //ViewBag.HeaderImage = image1.Path.ToString();

            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult BlogPost()
        {
            ViewBag.popularWord = DB.Tagstbl.ToList();
            var bloglist = DB.Blogtbl.ToList();
            return View(bloglist);
        }

        public ActionResult MakeThumbnail()
        {
            Infrustructure.Image image = new Image();
            image.MakeThumbnail("");
            return View();
        }

        public ActionResult UserProfilo()
        {
            return View();
        }
    }
}
