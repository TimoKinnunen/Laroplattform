namespace Läroplattform.Migrations
{
    using Helpers;
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            if (!HelpRole.RoleExists("Lärare"))
            {
                var success = HelpRole.CreateRole("Lärare");
            }

            if (!HelpRole.RoleExists("Elev"))
            {
                var success = HelpRole.CreateRole("Elev");
            }

            var lärareToInsert = new ApplicationUser
            {
                FirstName = "Stina",
                LastName = "Larsson",
                UserName = "stina.larsson@lexicon.se",
                Email = "stina.larsson@lexicon.se",
                EmailConfirmed = true
            };

            if (HelpRole.CreateUser(lärareToInsert, "Lexicon01!"))
            {
                var success = HelpRole.AddUserToRole(lärareToInsert.Id, "Lärare");
            }

            var elevToInsert = new ApplicationUser
            {
                FirstName = "Göran",
                LastName = "Persson",
                UserName = "goran.persson@lexicon.se",
                Email = "goran.persson@lexicon.se",
                EmailConfirmed = true
            };

            if (HelpRole.CreateUser(elevToInsert, "Lexicon01!"))
            {
                var success = HelpRole.AddUserToRole(elevToInsert.Id, "Elev");
            }
        }


    }
}
