using Läroplattform.Models;
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
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true)] //g Default date & time 10/12/2002 10:11 PM
        [Display(Name = "Course start date")]
        public DateTime StartDate { get; set; }

        // navigation property
        [Display(Name = "Course documents")]
        public virtual ICollection<Document> CourseDocuments { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }

    }
}