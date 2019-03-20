using System.Linq;
using System.Web.Mvc;
using FreelenceProjectDemo.Models;

namespace FreelenceProjectDemo.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _ctx;
        public HomeController()
        {
             _ctx = new ApplicationDbContext();
        }
        public ActionResult GetCoordinatorTcDetails(int id)
        {
            
           var ctc = _ctx.CoordinatorTrainingCourses
                .FirstOrDefault(c => c.CoordinatorTrainingCourseId == id);

            ViewBag.Count = _ctx.CoordinatorTrainingCourseDetails
                            .Count(c => c.CoordinatorTrainingCourseId == id);
            return View(ctc);
        }

    }
}