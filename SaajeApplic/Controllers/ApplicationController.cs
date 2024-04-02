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
            //var users = _userManager.Users.ToList();

            //var projet = new Projet
            //{
            //    Users = users.Select(u => new SelectListItem
            //    {
            //        Value = u.Id,
            //        Text = u.FirstName + " " + u.LastName
            //    }).ToList()
            //};
            //var users = await _userManager.Users.ToListAsync();
            //ViewBag.UsersList = new SelectList(users, "Id", "LastName"); // Supposons que vous avez une propriété FullName dans ApplicationUser

            var users = await _userManager.Users.Select(u => new SelectListItem
            {
                Value = u.Id,
                Text = u.FirstName + " " + u.LastName
            }).ToListAsync();

            var model = new ProjetCreateVM
            {
                UsersList = users
            };


            //projet.Commentaires.Add(new Commentaire() );


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProjetCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var projet = new Projet
                {
                    
                    ProjetName = model.ProjetName,
                    PlanAction = model.PlanAction,
                    DateCloture = model.DateCloture,
                    DateDebut = model.DateDebut,
                    DateLine = model.DateLine,
                    EtatProjet = model.EtatProjet,
                    UserId = model.UserId
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
            var projet = _context.Projets.Include(p => p.Commentaires).FirstOrDefault(p => p.ProjetId == id);
            if (projet == null)
            {
                return NotFound();
            }
            return View(projet);
        }

        
    }
}
