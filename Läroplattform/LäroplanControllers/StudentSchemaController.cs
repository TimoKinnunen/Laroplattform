using Läroplattform.LäroplanViewModels;
using Läroplattform.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;

namespace Läroplattform.LäroplanControllers
{
    public class StudentSchemaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.CurrentUserMessage = string.Empty;
            if (User != null && User.IsInRole("elev"))
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var currentUser = userManager.FindById(User.Identity.GetUserId());

                var firstName = currentUser.FirstName;
                var lastName = currentUser.LastName;
                var email = currentUser.Email;

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
                ViewBag.CurrentUserMessage = "Student has not logged in yet!";
                return View();
            }
        }
    }
}
