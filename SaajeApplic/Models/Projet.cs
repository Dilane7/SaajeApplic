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

        [Required(ErrorMessage = "Le nom du projet est obligatoire")]
        [StringLength(maximumLength: 300, MinimumLength = 10)]
        [Display(Name = "Non du projet")]
        public string ProjetName { get; set; }

        [Required(ErrorMessage = "Le plan d'action est obligatoire")]
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
        public DateTime? DateCloture { get; set; }

        public List<Commentaire> Commentaires { get; set; } = new List<Commentaire>();

        public List<Probleme> Problemes { get; set; } = new List<Probleme>();

        public List<Tache> Taches { get; set; } = new List<Tache>();

        [ForeignKey("AppUsers")]
        [NotMapped]
        [Required(ErrorMessage = "Veuillez sélectionner un utilisateur")]
        public String? UserId { get; set; } 
        public virtual AppUser AppUsers { get; set; }

        
    }
}
