using EasyCash.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _usermanager;

        public RegisterController(UserManager<AppUser> usermanager)
        {
            _usermanager = usermanager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
