using SaajeApplic.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SaajeApplic.Models
{
    public class Projet
    {
        [Key]
        public int ProjetId { get; set; }

        [Required]
        [StringLength(maximumLength: 200, MinimumLength = 10)]
        [Display(Name = "Non du projet")]
        public string ProjetName { get; set; }

        [Display(Name = "Plan d'action")]
        public string PlanAction { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date de debut")]
        public DateTime DateDebut { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Delais")]
        public DateTime DateLine { get; set; }

        [Display(Name = "Etat du projet")]
        public string EtatProjet { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date de Cloture")]
        public DateTime DateCloture { get; set; }

        public List<Commentaire> Commentaires { get; set; }

        public List<Probleme> Problemes { get; set; }

        public List<Tache> Taches { get; set; }


        public String? UserId { get; set; }
        [ForeignKey("UserId")]
        [NotMapped]
        public virtual AppUser AppUsers { get; set; }
    }
}
