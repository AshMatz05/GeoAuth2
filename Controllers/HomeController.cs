using GeoAuth2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GeoAuth2.Data;
using System.Linq;
using GeoCoordinatePortable;

namespace GeoAuth2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly double _companyLatitude = 21.159; 
        private readonly double _companyLongitude = 72.773;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
                if (user != null)
                {
                    var userLocation = new GeoCoordinate(model.Latitude, model.Longitude);
                    var companyLocation = new GeoCoordinate(_companyLatitude, _companyLongitude);
                    if (userLocation.GetDistanceTo(companyLocation) <= 1000) // 100 meters radius
                    {
                        return RedirectToAction("Success");
                    }
                    else
                    {
                        ModelState.AddModelError("", "You are not within the company premises.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View("Index");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
