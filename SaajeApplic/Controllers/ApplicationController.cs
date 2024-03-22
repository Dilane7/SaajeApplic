using Microsoft.AspNetCore.Mvc;
using SaajeApplic.Areas.Identity.Data;
using SaajeApplic.Models;

namespace SaajeApplic.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly AppDbContext _context;

        public ApplicationController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Projet> projets;
            projets = _context.Projets.ToList();

            return View(projets);
        }

        public IActionResult Create()
        {
            Projet projet = new Projet();
            return View(projet);
        }
    }
}
