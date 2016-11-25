using Läroplattform.LäroplanModeller;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Läroplattform.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //public int CourseId { get; set; }
        //[ForeignKey("CourseId")]
        //public virtual Course Course { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Display(Name = "Full name")]
        public string FullName { get { return FirstName + " " + LastName; } }

        // navigation property
        [Display(Name = "User documents")]
        public virtual ICollection<Document> UserDocuments { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Läroplattform.LäroplanModeller.Activity> Activities { get; set; }

        public System.Data.Entity.DbSet<Läroplattform.LäroplanModeller.ActivityType> ActivityTypes { get; set; }

        public System.Data.Entity.DbSet<Läroplattform.LäroplanModeller.Module> Modules { get; set; }

        public System.Data.Entity.DbSet<Läroplattform.LäroplanModeller.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<Läroplattform.LäroplanModeller.Document> Documents { get; set; }

        public System.Data.Entity.DbSet<Läroplattform.LäroplanModeller.DocumentType> DocumentTypes { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //}
    }
}