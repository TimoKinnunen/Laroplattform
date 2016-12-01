namespace Läroplattform.Migrations
{
    using LäroplanModels;
    using LäroplanViewModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context) {
            //  This method will be called after migrating to the latest version.

            if (!RoleExists("Lärare")) {
                var success = CreateRole("Lärare");
            }

            if (!RoleExists("Elev")) {
                var success = CreateRole("Elev");
            }

            var userToInsert = new ApplicationUser {
                FirstName = "Alexander",
                LastName = "Jonsson",
                TimeOfRegistration = DateTime.Now,
                UserName = "alexander.jonsson@gympass.se",
                Email = "alexander.jonsson@gympass.se",
                EmailConfirmed = true
            };

            if (CreateUser(userToInsert, "Lexicon01!")) {
                var success = AddUserToRole(userToInsert.Id, "Elev");
            }

            var adminToInsert = new ApplicationUser {
                FirstName = "Stina",
                LastName = "Larsson",
                TimeOfRegistration = DateTime.Now,
                UserName = "stina.larsson@gympass.se",
                Email = "stina.larsson@gympass.se",
                EmailConfirmed = true
            };

            if (CreateUser(adminToInsert, "Lexicon01!")) {
                var success = AddUserToRole(adminToInsert.Id, "Lärare");
            }

            //Random random = new Random();

            //for (int i = 0; i < 10; i++) {
            //    context.GymClasses.AddOrUpdate(
            //        g => g.ClassName,
            //        new GymClass {
            //            ClassName = "Spinning" + i.ToString(),
            //            StartTime = DateTime.Now,
            //            Duration = TimeSpan.FromMinutes(Math.Max(3, random.Next(60))),
            //            Description = "Up " + i.ToString() + "and down along with music."
            //        });
            //}

            //context.SaveChanges();
        }

        public bool RoleExists(string roleName) {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            return roleManager.RoleExists(roleName);
        }


        public bool CreateRole(string roleName) {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var idResult = roleManager.Create(new IdentityRole(roleName));
            return idResult.Succeeded;
        }


        public bool CreateUser(ApplicationUser applicationUser, string password) {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var idResult = userManager.Create(applicationUser, password);
            return idResult.Succeeded;
        }


        public bool AddUserToRole(string applicationUserId, string roleName) {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var idResult = userManager.AddToRole(applicationUserId, roleName);
            return idResult.Succeeded;
        }
    }
}
