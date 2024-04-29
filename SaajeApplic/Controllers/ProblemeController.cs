using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SaajeApplic.Areas.Identity.Data;
using SaajeApplic.Models.ViewModel;
using SaajeApplic.Models;
using Microsoft.EntityFrameworkCore;

namespace SaajeApplic.Controllers
{
    public class ProblemeController : Controller
    {

        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ProblemeController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        [HttpPost]
        public IActionResult AddProbleme(ProjetDetailVM model)
        {

            // Créer une instance de probleme à partir des données du modèle
            var probleme = new Probleme
            {
                PbIntitule = model.Probleme.PbIntitule,
                PbDate = model.Probleme.PbDate,
                // Assignez d'autres propriétés de probleme en fonction de votre modèle
                ProjetId = model.Projet.ProjetId
            };

            // Ajoutez le probleme à la base de données
            _context.Problemes.Add(probleme);
            _context.SaveChanges();

            // Redirigez l'utilisateur vers la page de détails du projet
            return RedirectToAction("Details", "Application", new { id = model.Projet.ProjetId });


        }


        [HttpGet]
        public async Task<IActionResult> DeleteProbleme(int id, int projetId)
        {
            // Recherchez le commentaire dans la base de données en fonction de son ID
            var probleme = await _context.Problemes.FirstOrDefaultAsync(p => p.ProblemeId == id);

            // Vérifiez si le commentaire existe
            if ( probleme == null)
            {
                return NotFound();
            }



            // Supprimez le commentaire de la base de données
            _context.Problemes.Remove(probleme);
            await _context.SaveChangesAsync();

            // Redirigez vers la page de détails du projet
            return RedirectToAction("Details", "Application", new { id = projetId });
        }
    }
}
