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
            HomeViewModel Model = new HomeViewModel();
            int Length = 10;
            System.Collections.Generic.List<UserTask> Reversed = DB.Tasks.ToList();
            Reversed.Reverse();
            if (Reversed.Count < 10)
                Length = Reversed.Count;
            Model.LatestTasks = Reversed.Take(Length);

            Length = 10;
            System.Collections.Generic.List<UserTask> Rated = DB.Tasks.Where(c => c.TaskRatingCount > 0).ToList();
            if (Rated.OrderByDescending(c =>c.TaskRating / c.TaskRatingCount).ToList().Count < 10)
                Length = Rated.OrderByDescending(c => c.TaskRating / c.TaskRatingCount).ToList().Count;
            Model.RatedTasks = Rated.OrderByDescending(c => c.TaskRating / c.TaskRatingCount).Take(Length);
         

            Length = 10;
            if (DB.Tasks.Where(c => c.SolveCount == 0).ToList().Count < 10)
                Length = DB.Tasks.Where(c => c.SolveCount == 0).ToList().Count;
            Model.UnsolvedTasks = DB.Tasks.Where(c => c.SolveCount == 0).Take(Length);


            Length = 10;
            System.Collections.Generic.IEnumerable<ApplicationUser> RatedUsers = DB.Users.Where(c => c.Rating > 0);
            if (RatedUsers.OrderByDescending(c => c.Rating).ToList().Count < 10)
                Length = RatedUsers.OrderByDescending(c => c.Rating).ToList().Count;

            Model.RatedUsers = RatedUsers.OrderByDescending(c => c.Rating).Take(Length);
           
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
            ApplicationDbContext DB = new ApplicationDbContext();
            System.Collections.Generic.IEnumerable<UserTask> Model = DB.Tasks.AsEnumerable();
            return View(Model);
        }

        public ActionResult DeleteTask(int id)
        {
            ApplicationDbContext DB = new ApplicationDbContext();
            UserTask DeletingTask = DB.Tasks.First(c => c.UserTaskID == id);
            DB.Tasks.Remove(DeletingTask);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}