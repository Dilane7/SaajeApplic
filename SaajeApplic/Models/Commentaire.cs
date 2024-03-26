using SaajeApplic.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SaajeApplic.Models
{
    public class Commentaire
    {
        [Key]
        public int? CommentaireId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime ComDate { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Commentaire")]
        public string ComIntitule { get; set; }

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
