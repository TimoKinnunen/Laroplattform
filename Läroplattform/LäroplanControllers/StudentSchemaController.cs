using Läroplattform.Helpers;
using Läroplattform.LäroplanViewModels;
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
                var currentApplicationUser = HelpUser.GetCurrentApplicationUser(User);

                var firstName = currentApplicationUser.FirstName;
                var lastName = currentApplicationUser.LastName;
                var email = currentApplicationUser.Email;

                StudentSchema studentSchema = new StudentSchema
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email
                };

                ViewBag.CurrentUserMessage = studentSchema.FullName + " " + email;
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
