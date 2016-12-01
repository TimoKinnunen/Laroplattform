using Läroplattform.Helpers;
using Läroplattform.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Läroplattform.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private ApplicationSignInManager applicationSignInManager;
        private ApplicationUserManager applicationUserManager;

        public ApplicationUsersController()
        {
        }

        public ApplicationUsersController(ApplicationUserManager applicationUserManager, ApplicationSignInManager applicationSignInManager)
        {
            UserManager = applicationUserManager;
            SignInManager = applicationSignInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return applicationSignInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                applicationSignInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return applicationUserManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                applicationUserManager = value;
            }
        }
        // GET: ApplicationUsers
        public ActionResult Index()
        {
            return View(UserManager.Users.ToList());
        }

        // GET: ApplicationUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = UserManager.FindById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Password,ConfirmPassword,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                UserManager.Create(applicationUser);
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }

        // GET: ApplicationUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = UserManager.FindById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                UserManager.Update(applicationUser);
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = UserManager.FindById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = UserManager.FindById(id);
            UserManager.Delete(applicationUser);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (applicationUserManager != null)
                {
                    applicationUserManager.Dispose();
                    applicationUserManager = null;
                }

                if (applicationSignInManager != null)
                {
                    applicationSignInManager.Dispose();
                    applicationSignInManager = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}
