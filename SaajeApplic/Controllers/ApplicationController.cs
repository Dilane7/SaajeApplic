using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SaajeApplic.Areas.Identity.Data;
using SaajeApplic.Models;


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

        

        public IActionResult Create()
        {
            var users = _userManager.Users.ToList();

            var projet = new Projet
            {
                Users = users.Select(u => new SelectListItem
                {
                    Value = u.Id,
                    Text = u.FirstName + " " + u.LastName
                }).ToList()
            };
            
            
           
            projet.Commentaires.Add(new Commentaire() );
            
            
            return View(projet);
        }

        [HttpPost]
        public IActionResult Create(Projet projet)
        {
            
            
            _context.Add(projet);
            _context.SaveChanges();
            return RedirectToAction("Index");
            

            
        }
    }
}
