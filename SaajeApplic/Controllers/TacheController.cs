using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SaajeApplic.Areas.Identity.Data;
using SaajeApplic.Models.ViewModel;
using SaajeApplic.Models;
using Microsoft.EntityFrameworkCore;

namespace SaajeApplic.Controllers
{
    public class TacheController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public TacheController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        [HttpPost]
        public IActionResult AddTache(ProjetDetailVM model)
        {

            // Créer une instance de Commentaire à partir des données du modèle
            var tache = new Tache
            {
                TacheDescription = model.Tache.TacheDescription,
                TacheDate = model.Tache.TacheDate,
                // Assignez d'autres propriétés de commentaire en fonction de votre modèle
                ProjetId = model.Projet.ProjetId
            };

            // Ajoutez le commentaire à la base de données
            _context.Taches.Add(tache);
            _context.SaveChanges();

            // Redirigez l'utilisateur vers la page de détails du projet
            return RedirectToAction("Details", "Application", new { id = model.Projet.ProjetId });


        }


        [HttpGet]
        public async Task<IActionResult> DeleteTache(int id, int projetId)
        {
            // Recherchez le commentaire dans la base de données en fonction de son ID
            var tache = await _context.Taches.FirstOrDefaultAsync(t => t.TacheId == id);

            // Vérifiez si le commentaire existe
            if (tache == null)
            {
                return NotFound();
            }



            // Supprimez le commentaire de la base de données
            _context.Taches.Remove(tache);
            await _context.SaveChangesAsync();

            // Redirigez vers la page de détails du projet
            return RedirectToAction("Details", "Application", new { id = projetId });
        }


    }
}
