using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SaajeApplic.Areas.Identity.Data;
using SaajeApplic.Models;
using SaajeApplic.Models.ViewModel;


namespace SaajeApplic.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ApplicationController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
           
        }
        public IActionResult Index()
        {
            List<Projet> projets;
            projets = _context.Projets.ToList();

            return View(projets);
        }

        

        public async Task<IActionResult> Create()
        {
            

            var users = await _userManager.Users.Select(u => new SelectListItem
            {
                Value = u.Id,
                Text = u.FirstName + " " + u.LastName
            }).ToListAsync();

            var model = new ProjetCreateVM
            {
                UsersList = users
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjetCreateVM model)
        {
            if (ModelState.IsValid)

            {
                var user = _userManager.Users.FirstOrDefault(x => x.Id == model.UserId);
                var projet = new Projet
                {
                    AppUsers = user,
                    ProjetName = model.ProjetName,
                    PlanAction = model.PlanAction,
                    
                    DateDebut = model.DateDebut,
                    DateLine = model.DateLine,
                    EtatProjet = model.EtatProjet,
                    
                };

                _context.Add(projet);
                _context.SaveChanges();
                return RedirectToAction("Index");


            }

            var users = await _userManager.Users.Select(u => new SelectListItem
            {
                Value = u.Id,
                Text = u.FirstName + " " + u.LastName
            }).ToListAsync();

            model.UsersList = users;

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var projet = _context.Projets.Include(p => p.Commentaires).Include(c => c.Taches).Include(a => a.Problemes).FirstOrDefault(p => p.ProjetId == id);
            if (projet == null)
            {
                return NotFound();
            }
            return View(new ProjetDetailVM {Projet = projet });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int projetId)
        {
            // Recherchez le projet dans la base de données en fonction de son ID
            var projet = await _context.Projets.FirstOrDefaultAsync(p => p.ProjetId == projetId);

            // Vérifiez si le projet existe
            if (projet == null)
            {
                return NotFound();
            }



            // Supprimez le projet de la base de données
            _context.Projets.Remove(projet);
            await _context.SaveChangesAsync();

            // Redirigez vers la page de détails du projet
            return RedirectToAction("Index");
        }




        //GET: Projets/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projet = await _context.Projets.FindAsync(id);
            if (projet == null)
            {
                return NotFound();
            }


           


            var users = await _userManager.Users.Select(u => new SelectListItem
            {
                Value = u.Id,
                Text = u.FirstName + " " + u.LastName
            }).ToListAsync();
            var projetEditVM = new ProjetCreateVM
            {
                ProjetId = projet.ProjetId,
                ProjetName = projet.ProjetName,
                UserId = projet.UserId,
                PlanAction = projet.PlanAction,
                DateDebut = projet.DateDebut,
                DateLine = projet.DateLine,
                EtatProjet = projet.EtatProjet,
                UsersList = users
            };

            return View(projetEditVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProjetCreateVM projetEditVM)
        {
            if (id != projetEditVM.ProjetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var projet = await _context.Projets.FindAsync(id);
                    projet.ProjetName = projetEditVM.ProjetName;
                    projet.UserId = projetEditVM.UserId;
                    projet.PlanAction = projetEditVM.PlanAction;
                    projet.DateDebut = projetEditVM.DateDebut;
                    projet.DateLine = projetEditVM.DateLine;
                    projet.EtatProjet = projetEditVM.EtatProjet;

                    _context.Update(projet);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetExists(projetEditVM.ProjetId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        return RedirectToAction(nameof(Edit), new { id = projetEditVM.ProjetId });
                    }
                }
            }
            // Prepare user list again in case of validation errors
            projetEditVM.UsersList = (IEnumerable<SelectListItem>)await _context.Users.Select(u => new { Value = u.Id, Text = u.UserName }).ToListAsync();
            return View(projetEditVM);
        }

        private bool ProjetExists(int id)
        {
            return _context.Projets.Any(e => e.ProjetId == id);
        }

    }
}
