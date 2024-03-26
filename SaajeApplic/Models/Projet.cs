using SaajeApplic.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SaajeApplic.Models
{
    public class Projet
    {
        [Key]
        public int ProjetId { get; set; }

        [Required]
        [StringLength(maximumLength: 300, MinimumLength = 10)]
        [Display(Name = "Non du projet")]
        public string ProjetName { get; set; }

        [Display(Name = "Plan d'action")]
        public string PlanAction { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date de debut")]
        public DateTime DateDebut { get; set; } = DateTime.Today;

        [DataType(DataType.Date)]
        [Display(Name = "Delais")]
        public DateTime DateLine { get; set; } = DateTime.Today;

        [Display(Name = "Etat du projet")]
        public string EtatProjet { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Date de Cloture")]
        public DateTime DateCloture { get; set; } = DateTime.Today;

        public List<Commentaire> Commentaires { get; set; } = new List<Commentaire>();

        public List<Probleme> Problemes { get; set; }

        public List<Tache> Taches { get; set; }

        [ForeignKey("AppUsers")]
        [NotMapped]
        public String? UserId { get; set; } 
        public virtual AppUser AppUsers { get; set; } = new AppUser();

        [NotMapped]
        public IEnumerable<SelectListItem> Users { get; set; } = new SelectListItem[0];
    }
}
