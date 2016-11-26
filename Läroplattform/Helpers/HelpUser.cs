using Läroplattform.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Läroplattform.Helpers
{
    public class HelpUser
    {
        public static ApplicationUser GetCurrentApplicationUser(IPrincipal User)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentApplicationUser = userManager.FindById(User.Identity.GetUserId());
            return currentApplicationUser;
        }
    }
}