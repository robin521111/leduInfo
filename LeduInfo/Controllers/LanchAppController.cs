using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeduInfo.Controllers
{
    public class LunchAppController : Controller
    {
        //
        // GET: /LanchApp/

        public ActionResult DishesChoice()
        {
            return View();
        }

        //public string RandomNum()
        //{
        //    //Random r = new Random();
        //    //int i = r.Next(1, 100);

        //    //return i.ToString();
        //}
    }
}
