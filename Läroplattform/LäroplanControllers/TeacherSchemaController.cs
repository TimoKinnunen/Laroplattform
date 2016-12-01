using Läroplattform.Models;
using System.Web.Mvc;

namespace Läroplattform.LäroplanControllers
{
    public class TeacherSchemaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.CurrentUserMessage = string.Empty;
            if (User.IsInRole("Lärare"))
            {
                ViewBag.CurrentUserMessage = "Lärare är inloggad.";
                return View();
            }
            else
            {
                ViewBag.CurrentUserMessage = "Teacher has not logged in yet!";
                return View();
            }
        }
    }
}
