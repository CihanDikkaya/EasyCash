using EasyCash.DTOLayer.DTOS.AppUserDTO;
using EasyCash.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.PresentationLayer.Controllers
{
    [Authorize]
    public class MyAccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MyAccountsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserEditDTO appUserEditDTO = new AppUserEditDTO();
            appUserEditDTO.Name = values.Name;
            appUserEditDTO.Surname = values.Surname;
            appUserEditDTO.PhoneNumber = values.PhoneNumber;
            appUserEditDTO.ImageURL = values.ImageURL;
            appUserEditDTO.Email = values.Email;
            appUserEditDTO.City = values.City;
            appUserEditDTO.District = values.District;

            return View(appUserEditDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDTO appUserEditDTO)
        {
            if (appUserEditDTO.Password == appUserEditDTO.ConfirmPassword)
            {


                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.PhoneNumber = appUserEditDTO.PhoneNumber;
                user.Surname = appUserEditDTO.Surname;
                user.City = appUserEditDTO.City;
                user.District = appUserEditDTO.District;
                user.Name = appUserEditDTO.Name;
                user.ImageURL = "Test";
                user.Email = appUserEditDTO.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDTO.Password);
                var result= await _userManager.UpdateAsync(user);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }
    }
}
