using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SaajeApplic.Areas.Identity.Data;
using SaajeApplic.Models;
using System.Diagnostics;

namespace SaajeApplic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserManager<AppUser> _userMager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            this._userMager = userManager;
        }

        public IActionResult Index()
        {
            _userMager.GetUserId(this.User);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
