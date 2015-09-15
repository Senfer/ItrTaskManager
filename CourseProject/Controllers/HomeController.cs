using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseProject.Models;

namespace CourseProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index( )
        {
            ApplicationDbContext DB = new ApplicationDbContext();
            System.Collections.Generic.IEnumerable<UserTask> Model = DB.Tasks.AsEnumerable();
            return View(Model);
        }

        public ActionResult About( )
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact( )
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FullTable()
        {

            return View();
        }
    }
}