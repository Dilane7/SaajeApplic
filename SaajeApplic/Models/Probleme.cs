﻿using SaajeApplic.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SaajeApplic.Models
{
    public class Probleme
    {
        [Key]
        public int ProblemeId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime PbDate { get; set; } = DateTime.Today;

        [DataType(DataType.MultilineText)]
        [Display(Name = "Probleme")]
        public string PbIntitule { get; set; }

        public int? ProjetId { get; set; }
        [ForeignKey("ProjetId")]
        [NotMapped]
        public virtual Projet Projets { get; set; }


        [ForeignKey("AppUsers")]
        [NotMapped]
        public String? UserId { get; set; }
        public virtual AppUser AppUsers { get; set; }
    }
}
