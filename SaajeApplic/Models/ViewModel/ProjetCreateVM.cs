using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaajeApplic.Models.ViewModel
{
    public class ProjetCreateVM
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
        public DateTime? DateCloture { get; set; } = DateTime.Today;

        [ForeignKey("AppUsers")]
        [NotMapped]
        [Required(ErrorMessage = "Veuillez sélectionner un utilisateur")]
        public String? UserId { get; set; }
        public IEnumerable<SelectListItem> UsersList { get; set; } = new List<SelectListItem>();
    }
}
