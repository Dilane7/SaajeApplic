using System.ComponentModel.DataAnnotations;

namespace SaajeApplic.Models.ViewModel
{
    public class ProjetDetailVM
    {
        public Projet Projet { get; set; }

        public Probleme Probleme { get; set; }

        public Tache Tache { get; set; }

        public Commentaire Commentaire { get; set; }
    }
}
