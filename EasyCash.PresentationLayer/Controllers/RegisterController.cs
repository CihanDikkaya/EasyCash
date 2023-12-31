﻿using EasyCash.DTOLayer.DTOS.AppUserDTO;
using EasyCash.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

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
				Random random = new Random();
				int code = random.Next(100000, 1000000);
				AppUser appUser = new AppUser()
				{
					UserName = appUserRegisterDTO.Username,
					Name = appUserRegisterDTO.Name,
					Surname = appUserRegisterDTO.Surname,
					Email = appUserRegisterDTO.Email,
					City = "aaaaaaa",
					District = "bbbbbb",
					ImageURL = "cccccccc",
					Confirmcode = code
				};
				var result = await _userManager.CreateAsync(appUser, appUserRegisterDTO.Password);
				if (result.Succeeded)
				{
					MimeMessage mimeMessage = new MimeMessage();
					MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "cihandikkaya09@gmail.com");
					MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

					mimeMessage.From.Add(mailboxAddressFrom);
					mimeMessage.To.Add(mailboxAddressTo);
					var bodyBuilder = new BodyBuilder();
					bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için Onay Kodunuz:" + code;
					mimeMessage.Body = bodyBuilder.ToMessageBody();
					mimeMessage.Subject = "Easy Cash Onay Kodu";
					SmtpClient client= new SmtpClient();
					client.Connect("smtp.gmail.com", 587, false);
					client.Authenticate("cihandikkaya09@gmail.com", "ewxc rrdg vfpj rskj");
					client.Send(mimeMessage);
					client.Disconnect(true);



					TempData["Mail"] = appUserRegisterDTO.Email;




					return RedirectToAction("Index", "ConfirmMail");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}

			}
			return View();
		}

	}
}
