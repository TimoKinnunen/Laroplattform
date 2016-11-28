using Läroplattform.Helpers;
using Läroplattform.LäroplanViewModels;
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
            if (User.IsInRole("lärare"))
            {
                var currentApplicationUser = HelpUser.GetCurrentApplicationUser(User);

                var firstName = currentApplicationUser.FirstName;
                var lastName = currentApplicationUser.LastName;
                var email = currentApplicationUser.Email;

                TeacherSchema teacherSchema = new TeacherSchema
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email
                };

                ViewBag.CurrentUserMessage = teacherSchema.FullName + " " + email;
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
