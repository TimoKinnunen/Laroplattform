using System.ComponentModel.DataAnnotations;

namespace Läroplattform.LäroplanModels
{
    public class ActivityType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Activity type")]
        public string Name { get; set; } = "E-learning";
    }
}