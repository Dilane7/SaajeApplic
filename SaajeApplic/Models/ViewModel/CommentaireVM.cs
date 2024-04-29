using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SaajeApplic.Models.ViewModel
{
    public class CommentaireVM
    {
        [Key]
        public int? CommentaireId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime ComDate { get; set; } = DateTime.Today;

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Commentaire")]
        public string ComIntitule { get; set; }

        public int? ProjetId { get; set; }
        [ForeignKey("ProjetId")]
        [NotMapped]
        public virtual Projet Projets { get; set; }
    }
}
