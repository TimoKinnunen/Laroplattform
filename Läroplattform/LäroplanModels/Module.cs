using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Läroplattform.LäroplanModels
{
    public class Module
    {
        [Key]
        public int Id { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [Required]
        [Display(Name = "Module name")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Module start date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Module end date")]
        public DateTime EndDate { get; set; }

        // navigation property
        [Display(Name = "Module documents")]
        public virtual ICollection<Document> ModuleDocuments { get; set; }
    }
}