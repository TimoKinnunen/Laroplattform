using System.ComponentModel.DataAnnotations;

namespace Läroplattform.LäroplanViewModels
{
    // class is only for view
    public class TeacherSchema
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Full name")]
        public string FullName { get { return FirstName + " " + LastName; } }

        [Display(Name = "E-post adress")]
        public string Email { get; set; }
    }
}