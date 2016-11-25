namespace Läroplattform.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Läroplattform.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            if (!RoleExists("lärare"))
            {
                var success = CreateRole("lärare");
            }

            if (!RoleExists("elev"))
            {
                var success = CreateRole("elev");
            }

            var lärareToInsert = new ApplicationUser
            {
                FirstName = "Stina",
                LastName = "Larsson",
                UserName = "stina.larsson@lexicon.se",
                Email = "stina.larsson@lexicon.se",
                EmailConfirmed = true
            };

            if (CreateUser(lärareToInsert, "Lexicon01!"))
            {
                var success = AddUserToRole(lärareToInsert.Id, "lärare");
            }
        }

        public bool RoleExists(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            return roleManager.RoleExists(roleName);
        }


        public bool CreateRole(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var idResult = roleManager.Create(new IdentityRole(roleName));
            return idResult.Succeeded;
        }


        public bool CreateUser(ApplicationUser applicationUser, string password)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var idResult = userManager.Create(applicationUser, password);
            return idResult.Succeeded;
        }


        public bool AddUserToRole(string applicationUserId, string roleName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var idResult = userManager.AddToRole(applicationUserId, roleName);
            return idResult.Succeeded;
        }
    }
}
