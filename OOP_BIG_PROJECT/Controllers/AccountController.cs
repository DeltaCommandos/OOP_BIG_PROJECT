﻿using Microsoft.AspNetCore.Mvc;
using OOP_BIG_PROJECT.Models;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using OOP_BIG_PROJECT.ViewModels;
using OOP_BIG_PROJECT.Data;
namespace OOP_BIG_PROJECT.Controllers
{
    //кнопку "начать поиск". аву в углу сделать. рядом с ней изменить фото. сделать изменить увлечения. меню с предстоящими боями. 
    // ник указать 
    public class AccountController : Controller
	{
		private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var response = new FighterViewModel();
            return View(response);
        }
        [HttpGet]
        public IActionResult Search()
        {
            var response = new FighterViewModel();
            return View(response);
        }
        [HttpGet]
        public IActionResult Accaunt()
        {
            var response = new FighterViewModel();
            return View(response);
        }
        [HttpPost]
        public IActionResult Index(FighterViewModel A)
        {
            return View(A);
        }
        [HttpPost]
        public IActionResult Search(FighterViewModel A)
        {
            return RedirectToAction("Search", "Match");
        }
        public IActionResult Account(FighterViewModel A)
        {
            return RedirectToAction("Account", "AccountHome");
        }

    }
}



















        //      private readonly UserManager<IdentityUser> _userManager;
        //private readonly SignInManager<IdentityUser> _signInManager;

//	public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
//	{
//		_userManager = userManager;
//		_signInManager = signInManager;
//	}

//	[HttpGet]
//	public IActionResult Register()
//	{
//		return View();
//	}

//	[HttpPost]
//	public async Task<IActionResult> Register(RegisterViewModel model)
//	{
//		if (ModelState.IsValid)
//		{
//			var user = new IdentityUser { UserName = model.Username, Username = model.Username };
//			var result = await _userManager.CreateAsync(user, model.Password);
//			if (result.Succeeded)
//			{
//				await _signInManager.SignInAsync(user, isPersistent: false);
//				return RedirectToAction("Index", "Home");
//			}
//			foreach (var error in result.Errors)
//			{
//				ModelState.AddModelError(string.Empty, error.Description);
//			}
//		}
//		return View(model);
//	}

//	[HttpGet]
//	public IActionResult Login()
//	{
//		return View();
//	}

//	[HttpPost]
//	public async Task<IActionResult> Login(LoginViewModel model)
//	{
//		if (ModelState.IsValid)
//		{
//			var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
//			if (result.Succeeded)
//			{
//				return RedirectToAction("Index", "Home");
//			}
//			ModelState.AddModelError(string.Empty, "Invalid login attempt.");
//		}
//		return View(model);
//	}