using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Läroplattform.LäroplanModels
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        public int ActivityTypeId { get; set; }
        [ForeignKey("ActivityTypeId")]
        public virtual ActivityType ActivityType { get; set; }

        public int ModuleId { get; set; }
        [ForeignKey("ModuleId")]
        public virtual Module Module { get; set; }

        [Required(ErrorMessage = "Du måste mata in aktivitetes namn.")]
        [Display(Name = "Activity name")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Activity start date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Activity end date")]
        public DateTime EndDate { get; set; }

        // navigation property
        [Display(Name = "Activity documents")]
        public virtual ICollection<Document> ActivityDocuments { get; set; }
    }
}