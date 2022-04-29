using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        
        public async Task<IActionResult> Authenticate()
        {
            var defaultClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "satish")
            };

            var defaultIdentityProvider = new ClaimsIdentity(defaultClaims, "default");
            var userPrincipal = new ClaimsPrincipal(defaultIdentityProvider);
            await HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("About");
        }
    }
}
