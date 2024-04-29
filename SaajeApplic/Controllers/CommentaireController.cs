using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using SaajeApplic.Areas.Identity.Data;
using SaajeApplic.Models;
using SaajeApplic.Models.ViewModel;

namespace SaajeApplic.Controllers
{
    public class CommentaireController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CommentaireController( AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        

        [HttpPost]
        public IActionResult AddCommentaire(ProjetDetailVM model)
        {
            
                // Créer une instance de Commentaire à partir des données du modèle
                var commentaire = new Commentaire
                {
                    ComIntitule = model.Commentaire.ComIntitule,
                    ComDate = model.Commentaire.ComDate,
                    // Assignez d'autres propriétés de commentaire en fonction de votre modèle
                    ProjetId = model.Projet.ProjetId
                };

                // Ajoutez le commentaire à la base de données
                _context.Commentaires.Add(commentaire);
                _context.SaveChanges();

                // Redirigez l'utilisateur vers la page de détails du projet
                return RedirectToAction("Details","Application", new { id = model.Projet.ProjetId });
            

        }



        [HttpGet]
        public async Task<IActionResult> DeleteComment(int id, int projetId)
        {
            // Recherchez le commentaire dans la base de données en fonction de son ID
            var commentaire = await _context.Commentaires.FirstOrDefaultAsync(c => c.CommentaireId == id);

            // Vérifiez si le commentaire existe
            if (commentaire == null)
            {
                return NotFound();
            }



            // Supprimez le commentaire de la base de données
            _context.Commentaires.Remove(commentaire);
            await _context.SaveChangesAsync();

            // Redirigez vers la page de détails du projet
            return RedirectToAction("Details", "Application", new { id = projetId });
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id ,int projetId )
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentaire = await _context.Commentaires.FindAsync(id);
            if (commentaire == null)
            {
                return NotFound();
            }


            var comment = new Commentaire
            {
                CommentaireId = commentaire.CommentaireId,
                ComIntitule = commentaire.ComIntitule
            };

            return RedirectToAction("Details", "Application", new { id = projetId });
        }


    }
}