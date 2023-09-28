using EasyCash.DTOLayer.DTOS.AppUserDTO;
using EasyCash.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDTO appUserRegisterDTO)
        {
            if (ModelState.IsValid)
            {
				AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDTO.Username,
                    Name = appUserRegisterDTO.Name,
                    Surname = appUserRegisterDTO.Surname,
                    Email = appUserRegisterDTO.Email
                };
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDTO.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "ConfirmMail");
                }
           
            }
            return View();
        }

    }
}
