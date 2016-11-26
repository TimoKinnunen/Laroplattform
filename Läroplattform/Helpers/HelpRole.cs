using Läroplattform.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Läroplattform.Helpers
{
    public class HelpRole
    {
        public static bool RoleExists(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            return roleManager.RoleExists(roleName);
        }


        public static bool CreateRole(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var idResult = roleManager.Create(new IdentityRole(roleName));
            return idResult.Succeeded;
        }


        public static bool CreateUser(ApplicationUser applicationUser, string password)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var idResult = userManager.Create(applicationUser, password);
            return idResult.Succeeded;
        }


        public static bool AddUserToRole(string applicationUserId, string roleName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var idResult = userManager.AddToRole(applicationUserId, roleName);
            return idResult.Succeeded;
        }
    }
}