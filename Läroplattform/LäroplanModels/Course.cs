using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Läroplattform.LäroplanModels
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Course name")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Course start date")]
        public DateTime StartDate { get; set; }

        // navigation property
        [Display(Name = "Course documents")]
        public virtual ICollection<Document> CourseDocuments { get; set; }
    }
}