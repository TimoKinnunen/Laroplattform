using Läroplattform.Models;
using System.Web.Mvc;

namespace Läroplattform.LäroplanControllers
{
    public class StudentSchemaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.CurrentUserMessage = string.Empty;
            if (User.IsInRole("Elev"))
            {
                ViewBag.CurrentUserMessage = "Elev är inloggad.";
                return View();
            }
            else
            {
                ViewBag.CurrentUserMessage = "Student has not logged in yet!";
                return View();
            }
        }
    }
}
