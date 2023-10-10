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
    }
}
