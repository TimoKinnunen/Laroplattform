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

            //if (!roleManager.RoleExists("Lärare")) {
            //    identityResult = roleManager.Create(new IdentityRole(("Lärare")));
            //    if (!identityResult.Succeeded) {
            //        throw new Exception("Error creating role 'Lärare' in seed.");
            //    }
            //}

            //if (!roleManager.RoleExists("Elev")) {
            //    identityResult = roleManager.Create(new IdentityRole(("Elev")));
            //    if (!identityResult.Succeeded) {
            //        throw new Exception("Error creating role 'Elev' in seed.");
            //    }
            //}

            var adminToInsert = new ApplicationUser {
                FirstName = "Stina",
                LastName = "Larsson",
                TimeOfRegistration = DateTime.Now,
                UserName = "stina.larsson@gympass.se",
                Email = "stina.larsson@gympass.se",
                EmailConfirmed = true
            };

            //applicationUser = userManager.FindByEmail("stina.larsson@lexicon.se");
            //if (applicationUser == null) {
            //    ApplicationUser newApplicationUser =
            //        new ApplicationUser {
            //            FirstName = "Stina",
            //            LastName = "Larsson",
            //            UserName = "stina.larsson@lexicon.se",
            //            Email = "stina.larsson@lexicon.se",
            //            TimeOfRegistration = DateTime.Now
            //        };
            //    identityResult = userManager.Create(newApplicationUser, "Lexicon01!");
            //    if (identityResult.Succeeded) {
            //        identityResult = userManager.AddToRole(newApplicationUser.Id, "Lärare");
            //        if (!identityResult.Succeeded) {
            //            throw new Exception("Error adding user 'stina.larsson@lexicon.se' to role 'Lärare' in seed.");
            //        }
            //    } else {
            //        throw new Exception("Error creating user 'stina.larsson@lexicon.se' in seed.");
            //    }
            //}

            //applicationUser = userManager.FindByEmail("goran.persson@lexicon.se");
            //if (applicationUser == null) {
            //    ApplicationUser newApplicationUser =
            //        new ApplicationUser {
            //            FirstName = "Göran",
            //            LastName = "Persson",
            //            UserName = "goran.persson@lexicon.se",
            //            Email = "goran.persson@lexicon.se",
            //            TimeOfRegistration = DateTime.Now
            //        };
            //    identityResult = userManager.Create(newApplicationUser, "Lexicon01!");
            //    if (identityResult.Succeeded) {
            //        identityResult = userManager.AddToRole(newApplicationUser.Id, "Elev");
            //        if (!identityResult.Succeeded) {
            //            throw new Exception("Error adding user 'goran.persson@lexicon.se' to role 'Elev' in seed.");
            //        }
            //    } else {
            //        throw new Exception("Error creating user 'goran.persson@lexicon.se' in seed.");
            //    }
            //}

            context.ActivityTypes.AddOrUpdate(
              p => p.Name,
              new ActivityType { Name = "E-learning" }
            );

            context.SaveChanges();

            context.DocumentTypes.AddOrUpdate(
              p => p.Name,
              new DocumentType { Name = "Inlämningsuppgift" }
            );

            context.SaveChanges();

            context.Courses.AddOrUpdate(
              p => p.Name,
              new Course { Name = "Systemutveckling .net", Description = "C#, JavaScript, Bootstrap, CSS, Html, MVC, Entity Framework", StartDate = DateTime.Now.AddMonths(-1) }
            );

            context.SaveChanges();


            context.SaveChanges();
        }
    }
}
