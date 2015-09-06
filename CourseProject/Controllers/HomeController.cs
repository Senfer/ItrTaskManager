using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseProject.Mailers;
using System.Net.Mail;

namespace CourseProject.Controllers
{
    public class HomeController : Controller
    {


        //   Mailer TODO
        private IUserMailer _userMailer = new UserMailer();
        public IUserMailer UserMailer
        {
            get { return _userMailer; }
            set { _userMailer = value; }
        }
        //
        public ActionResult SendWelcomeMessage( )
        {
            UserMailer.Welcome().Send(); //Send() extension method: using Mvc.Mailer
            return RedirectToAction( "Index" );
        }
        //




        public ActionResult Index( )
        {
            return View();
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
    }
}