using Läroplattform.LäroplanViewModels;
using Läroplattform.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Läroplattform.LäroplanControllers
{
    public class RegisterUserViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RegisterUserViewModels
        public ActionResult Index()
        {
            return View(db.RegisterUserViewModels.ToList());
        }

        // GET: RegisterUserViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterUserViewModel registerUserViewModel = db.RegisterUserViewModels.Find(id);
            if (registerUserViewModel == null)
            {
                return HttpNotFound();
            }
            return View(registerUserViewModel);
        }

        // GET: RegisterUserViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisterUserViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Password,ConfirmPassword")] RegisterUserViewModel registerUserViewModel)
        {
            if (ModelState.IsValid)
            {
                db.RegisterUserViewModels.Add(registerUserViewModel);
                db.SaveChanges();
                //var user = new ApplicationUser
                //{
                //    FirstName = registerUserViewModel.FirstName,
                //    LastName = registerUserViewModel.LastName,
                //    UserName = registerUserViewModel.Email,
                //    TimeOfRegistration = DateTime.Now,
                //    Email = registerUserViewModel.Email
                //};
                //var result = await UserManager.CreateAsync(user, registerUserViewModel.Password);
                return RedirectToAction("Index");
            }

            return View(registerUserViewModel);
        }

        // GET: RegisterUserViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterUserViewModel registerUserViewModel = db.RegisterUserViewModels.Find(id);
            if (registerUserViewModel == null)
            {
                return HttpNotFound();
            }
            return View(registerUserViewModel);
        }

        // POST: RegisterUserViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Password,ConfirmPassword")] RegisterUserViewModel registerUserViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registerUserViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registerUserViewModel);
        }

        // GET: RegisterUserViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterUserViewModel registerUserViewModel = db.RegisterUserViewModels.Find(id);
            if (registerUserViewModel == null)
            {
                return HttpNotFound();
            }
            return View(registerUserViewModel);
        }

        // POST: RegisterUserViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisterUserViewModel registerUserViewModel = db.RegisterUserViewModels.Find(id);
            db.RegisterUserViewModels.Remove(registerUserViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
