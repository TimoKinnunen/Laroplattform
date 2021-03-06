﻿using System.ComponentModel.DataAnnotations;

namespace Läroplattform.LäroplanModels
{
    public class DocumentType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Document type")]
        public string Name { get; set; } = "Inlämningsuppgift";
    }
}